using RotaryClub.Data;
using RotaryClub.Models;

namespace RotaryClub.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<Status> Create(Project project);
        Task<Status> Update(Project project);
        Task<Status> Delete(Project project);
        Task<IEnumerable<Project>> GetLastThreeProjects();
        Task<int> Count();
    }
}
