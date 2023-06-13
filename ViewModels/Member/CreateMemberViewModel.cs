using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels.Member
{
    public class CreateMemberViewModel
    {
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public bool Honorary { get; set; } = false;
    }
}
