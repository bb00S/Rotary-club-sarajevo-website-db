using RotaryClub.ViewModels.Tasks;

namespace RotaryClub.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EditTasksViewModel ToEditViewModel()
        {
            return new EditTasksViewModel
            {
                Title = Title,
                Content = Content,
            };
        }
    }
}
