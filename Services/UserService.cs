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

        public Status CreateUser(UserRegisterViewModel request)
        {
            if (request.Keyword != _configuration.GetValue<string>("Keyword"))
                return new Status("Wrong keyword");

            if (CheckIfExists(request.Email))
                return new Status("User already exists");
            
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
            return new Status();
        }

        public Status GetUser(string email, string password)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
                return new Status("User not found");
            var result = user.Result;
            if (result.VerifiedAt == null)
                return new Status("User not verified! Please check your email.");
            if (!VerifyPasswordHash(password, result.PasswordHash, result.PasswordSalt))
                return new Status("Incorrect password!");
            return new Status();
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

        public async Task<Status> VerifyUser(string token)
        {
            var user = await _userRepository.VerifyToken(token);
            if (user == null)
                return new Status("User not found");
            return new Status();
        }

        public async Task<Status> CreateResetTokenAsync(string email)
        {
            var user = await _userRepository.GetUser(email);
            if (user == null)
                return new Status("User not found");
            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(2);
            await _userRepository.UpdateUser(user);
            _emailSenderService.SendPasswordResetEmail(user);
            return new Status();
        }

        public async Task<Status> CheckPasswordToken(string token)
        {
            var user = await _userRepository.GetUserByPasswordToken(token);
            if (user == null)
                return new Status("User not found");
            if (user.ResetTokenExpires < DateTime.Now)
                return new Status("Token has expired");
            return new Status();
        }

        public async Task<Status> ResetPassword(ResetPasswordViewModel request)
        {
            var user = await _userRepository.GetUserByPasswordToken(request.Token);
            if (user == null)
                return new Status("Token doesn't exist");
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ResetTokenExpires = DateTime.Now.AddHours(-100);
            await _userRepository.UpdateUser(user);
            return new Status();
        }
    }
}
