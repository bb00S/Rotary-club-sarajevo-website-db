using RotaryClub.Data;
using RotaryClub.ViewModels.User;

namespace RotaryClub.Interfaces
{
    public interface IUserService
    { 

        void Login (string username, HttpContext httpContext);
        Status CreateUser(UserRegisterViewModel request);
        Status GetUser(string email, string password);
        Task<Status> VerifyUser(string token);
        Task<Status> CreateResetTokenAsync(string email);
        Task<Status> CheckPasswordToken(string token);
        Task<Status> ResetPassword(ResetPasswordViewModel request);
    }
}
