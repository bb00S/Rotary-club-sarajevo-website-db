using RotaryClub.Data;
using RotaryClub.Models;

namespace RotaryClub.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAll();
        Task<Tasks> GetById(int id);
        Task<Status> Create(Tasks tasks);
        Task<Status> Update(Tasks tasks);
        Task<Status> Delete(Tasks tasks);
        Task<IEnumerable<Tasks>> GetLastThreeTasks();
        Task<int> Count();
    }
}
