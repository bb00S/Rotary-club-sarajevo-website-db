using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Project;

namespace RotaryClub.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<Status> Create(Project project);
        Task<Status> Update(Project project);
        Task<Status> Delete(Project project);
    }
}
