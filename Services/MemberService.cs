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
            var photoPath = await _photoService.Create(viewModel.Photo, "members");
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

        public async Task<Status> Delete(int id)
        {
            var member = await _memberRepository.GetById(id);
            if (member == null)
                return new Status("Member not found");

            var status = _photoService.Delete(member.PhotoUrl);
            if (!status.Success)
                return status;

            status = await _memberRepository.Delete(member);
            if (!status.Success)
                return status;

            return new Status();
        }

        public Task<IEnumerable<Member>> GetAll()
        {
            return _memberRepository.GetAll();
        }

        public Task<Member> GetById(int id)
        {
            return _memberRepository.GetById(id);
        }

        public async Task<Status> Update(int id, EditMemberViewModel viewModel)
        {
            var member = await _memberRepository.GetById(id);
            if (viewModel.Photo != null)
            {
                _photoService.Delete(member.PhotoUrl);
                member.PhotoUrl = await _photoService.Create(viewModel.Photo, "members");
            }
            member.Email = viewModel.Email;
            member.Honorary = viewModel.Honorary;
            member.Website = viewModel.Website;
            member.UpdatedAt = DateTime.Now;
            member.Name = viewModel.Name;
            return await _memberRepository.Update(member);
        }
    }
}
