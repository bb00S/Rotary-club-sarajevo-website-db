using RotaryClub.Data;

namespace RotaryClub.Interfaces
{
    public interface IUserService
    {
        UserStatus CreateUser(string email, string password);
        UserStatus GetUser(string email, string password);
    }
}
