using RotaryClub.Data;
using RotaryClub.ViewModels.User;

namespace RotaryClub.Interfaces
{
    public interface IUserService
    { 

        void Login (string username, HttpContext httpContext);
        UserStatus CreateUser(UserRegisterViewModel request);
        UserStatus GetUser(string email, string password);
        Task<UserStatus> VerifyUser(string token);
        Task<UserStatus> CreateResetTokenAsync(string email);
        Task<UserStatus> CheckPasswordToken(string token);
        Task<UserStatus> ResetPassword(ResetPasswordViewModel request);
    }
}
