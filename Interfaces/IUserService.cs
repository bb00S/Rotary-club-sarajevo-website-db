using RotaryClub.Data;
using RotaryClub.ViewModels;

namespace RotaryClub.Interfaces
{
    public interface IUserService
    { 

        void Login (string username, HttpContext httpContext);
        UserStatus CreateUser(string email, string password);
        UserStatus GetUser(string email, string password);
    }
}
