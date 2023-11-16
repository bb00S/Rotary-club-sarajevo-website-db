using RotaryClub.ViewModels.Project;

namespace RotaryClub.Models
{ 
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EditProjectViewModel ToEditViewModel()
        {
            return new EditProjectViewModel
            {
                Title = Title,
                SubTitle = SubTitle,
                PhotoUrl = PhotoUrl,
                Content = Content,
            };
        }
    }
}
