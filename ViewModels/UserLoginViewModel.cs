using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels
{
    public class UserLoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
