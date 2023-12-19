using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Tasks;

namespace RotaryClub.Interfaces
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAll();
        Task<Tasks> GetById(int id);
        Task<Status> Create(CreateTasksViewModel viewModel);
        Task<Status> Update(int id, EditTasksViewModel viewModel);
        Task<Status> Delete(int id);
        Task<IEnumerable<Tasks>> GetLastThreeTasks();
        Task<int> Count();
    }
}
