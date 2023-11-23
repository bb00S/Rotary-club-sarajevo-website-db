using Microsoft.EntityFrameworkCore;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {

            _context = context;

        }

        private async Task<Status> Save()
        {
            var saved = await _context.SaveChangesAsync();
            if (saved > 0)
                return new Status();
            return new Status("Database error!");
        }

        public async Task<Status> Create(Project project)
        {
            _context.Projects.Add(project);
            return await Save();
        }

        public Task<Status> Delete(Project project)
        {
            _context.Remove(project);
            return Save();
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Status> Update(Project project)
        {
            _context.Projects.Update(project);
            return await Save();
        }

    }
}
