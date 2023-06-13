using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<Status> Create(CreateMemberViewModel viewModel);
        Task<Status> Update(CreateMemberViewModel viewModel);
        Task<Status> Delete(CreateMemberViewModel viewModel);
    }
}
