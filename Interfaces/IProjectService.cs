using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Admin;
using RotaryClub.ViewModels.Project;

namespace RotaryClub.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<Status> Create(CreateProjectViewModel viewModel);
        Task<Status> Update(int id, EditProjectViewModel viewModel);
        Task<Status> Delete(int id);
        Task<IEnumerable<Project>> GetLastThreeProjects();
        Task<int> Count(); //

    }
}
