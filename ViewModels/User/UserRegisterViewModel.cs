using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels.User
{
    public class UserRegisterViewModel
    {
        [Required, EmailAddress(ErrorMessage = "Email field must contain an email")]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Password treba imati najmanje 6 karaktera")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password", ErrorMessage = "Password and Confirm password field must match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string Keyword { get; set; } = string.Empty;
    }
}
