using Microsoft.EntityFrameworkCore;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Repository
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

        public async Task<User> GetUser(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
