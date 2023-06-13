using Microsoft.EntityFrameworkCore;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public bool CheckIfExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public async Task<User> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByPasswordToken(string token)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> VerifyToken(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user != null) {
                user.VerifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
