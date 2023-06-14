using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels.Member
{
    public class EditMemberViewModel
    {
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public bool Honorary { get; set; } = false;
    }
}
