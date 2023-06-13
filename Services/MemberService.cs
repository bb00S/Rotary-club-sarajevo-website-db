using Azure;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPhotoService _photoService;
        public MemberService(IMemberRepository memberRepository, IPhotoService photoService)
        {
            _memberRepository = memberRepository;
            _photoService = photoService;
        }
        public async Task<Status> Create(CreateMemberViewModel viewModel)
        {
            var photoPath = await _photoService.Create(viewModel.Photo);
            if (photoPath == null)
                return new Status("Photo upload failed");
            Member member = new()
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhotoUrl = photoPath,
                Honorary = viewModel.Honorary,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Website = viewModel.Website
            };
            return await _memberRepository.Create(member);
        }

        public Task<Status> Delete(CreateMemberViewModel viewModel)
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

        public Task<Status> Update(CreateMemberViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
