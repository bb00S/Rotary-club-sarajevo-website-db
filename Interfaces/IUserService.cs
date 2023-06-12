using RotaryClub.Data;
using RotaryClub.ViewModels;

namespace RotaryClub.Interfaces
{
    public interface IUserService
    { 

        void Login (string username, HttpContext httpContext);
        UserStatus CreateUser(UserRegisterViewModel request);
        UserStatus GetUser(string email, string password);
    }
}
