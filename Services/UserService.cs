using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;
using System.Security.Cryptography;

namespace RotaryClub.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public UserStatus CreateUser(string email, string password)
        {
            if (CheckIfExists(email))
                return new UserStatus("User already exists");
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            _userRepository.AddUser(user);

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
    }
}
