using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<Status> Create(Member member);
        Task<Status> Update(Member member);
        Task<Status> Delete(Member member);
    }
}
