using RotaryClub.Models;

namespace RotaryClub.Interfaces
{
    public interface IUserRepository
    {
        bool CheckIfExists(string email);
        Task<User> GetUser(string email);
        Task AddUser(User user);
        Task<User> VerifyToken(string token);
    }
}
