using Microsoft.EntityFrameworkCore;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DataContext _context;
        public TasksRepository(DataContext context)
        {

            _context = context;

        }

        public async Task<Status> Create(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            return await Save();
        }

        private async Task<Status> Save()
        {
            var saved = await _context.SaveChangesAsync();
            if (saved > 0)
                return new Status();
            return new Status("Database error!");
        }

        public Task<Status> Delete(Tasks tasks)
        {
            _context.Remove(tasks);
            return Save();
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<Status> Update(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            return await Save();
        }

        public async Task<IEnumerable<Tasks>> GetLastThreeTasks()
        {
            return await _context.Tasks.OrderByDescending(r => r.CreatedAt).Take(3).ToListAsync();
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> Count()
        {
            return await _context.Tasks.CountAsync();
        }
    }
}
