using System.ComponentModel.DataAnnotations;

namespace RotaryClub.ViewModels.Project
{
    public class EditProjectViewModel
    {
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
