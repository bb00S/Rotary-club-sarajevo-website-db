using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RotaryClub.ViewModels.Tasks
{
    public class CreateTasksViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
