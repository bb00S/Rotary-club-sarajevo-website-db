﻿using RotaryClub.Data;
using RotaryClub.Models;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<Status> Create(CreateMemberViewModel viewModel);
        Task<Status> Update(int id, CreateMemberViewModel viewModel);
        Task<Status> Delete(int id);
    }
}