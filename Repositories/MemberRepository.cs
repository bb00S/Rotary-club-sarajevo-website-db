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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Member>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Status> Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
