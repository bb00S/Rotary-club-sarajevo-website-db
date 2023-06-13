using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels.User
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Password treba imati najmanje 6 karaktera")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password", ErrorMessage = "Password and Confirm password field must match")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
