using Microsoft.EntityFrameworkCore;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context)
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

        public async Task<Status> Create(Member member)
        {
            _context.Members.Add(member);
            return await Save();
        }

        public Task<Status> Delete(Member member)
        {
            _context.Remove(member);
            return Save();
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Member> GetById(int id)
        {
            return await _context.Members.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Status> Update(Member member)
        {
            _context.Members.Update(member);
            return await Save();
        }
    }
}
