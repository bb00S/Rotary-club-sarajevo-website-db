using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;
using RotaryClub.ViewModels.User;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RotaryClub.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IEmailSenderService _emailSenderService;
        public UserService(IUserRepository userRepository, IConfiguration configuration, IEmailSenderService emailSenderService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _emailSenderService = emailSenderService;
        }

        private bool CheckIfExists(string email)
        {
            return _userRepository.CheckIfExists(email);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public UserStatus CreateUser(UserRegisterViewModel request)
        {
            if (request.Keyword != _configuration.GetValue<string>("Keyword"))
                return new UserStatus("Wrong keyword");

            if (CheckIfExists(request.Email))
                return new UserStatus("User already exists");
            
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            _userRepository.AddUser(user);
            _emailSenderService.SendVerificationEmail(user);
            return new UserStatus();
        }

        public UserStatus GetUser(string email, string password)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
                return new UserStatus("User not found");
            var result = user.Result;
            if (result.VerifiedAt == null)
                return new UserStatus("User not verified! Please check your email.");
            if (!VerifyPasswordHash(password, result.PasswordHash, result.PasswordSalt))
                return new UserStatus("Incorrect password!");
            return new UserStatus();
        }

        public async void Login(string username, HttpContext httpContext)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, username),
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true
            };

            await httpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme,
                                                                  new ClaimsPrincipal(claimsIdentity),
                                                                  properties);
        }

        public async Task<UserStatus> VerifyUser(string token)
        {
            var user = await _userRepository.VerifyToken(token);
            if (user == null)
                return new UserStatus("User not found");
            return new UserStatus();
        }

        public async Task<UserStatus> CreateResetTokenAsync(string email)
        {
            var user = await _userRepository.GetUser(email);
            if (user == null)
                return new UserStatus("User not found");
            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(2);
            await _userRepository.UpdateUser(user);
            _emailSenderService.SendPasswordResetEmail(user);
            return new UserStatus();
        }

        public async Task<UserStatus> CheckPasswordToken(string token)
        {
            var user = await _userRepository.GetUserByPasswordToken(token);
            if (user == null)
                return new UserStatus("User not found");
            if (user.ResetTokenExpires < DateTime.Now)
                return new UserStatus("Token has expired");
            return new UserStatus();
        }

        public async Task<UserStatus> ResetPassword(ResetPasswordViewModel request)
        {
            var user = await _userRepository.GetUserByPasswordToken(request.Token);
            if (user == null)
                return new UserStatus("Token doesn't exist");
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ResetTokenExpires = DateTime.Now.AddHours(-100);
            await _userRepository.UpdateUser(user);
            return new UserStatus();
        }
    }
}
