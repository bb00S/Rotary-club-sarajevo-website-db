using RotaryClub.Models;

namespace RotaryClub.Interfaces
{
    public interface IEmailSenderService
    {
        public void SendContactEmail(Email email);
        public void SendVerificationEmail(User user);

        void SendPasswordResetEmail(User user);
    }
}
