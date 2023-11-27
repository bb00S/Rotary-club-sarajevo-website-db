using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.Repositories;
using RotaryClub.Services;
using RotaryClub.ViewModels.Admin;

namespace RotaryClub.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMemberService _memberService;

        public AdminController(IProjectService ps, IMemberService ms)
        {
            _projectService = ps;
            _memberService = ms;
        }
        public async Task<IActionResult> Index()
        {
			int totalProjectCount = await _projectService.Count();

			var viewModel = new AdminViewModel
			{
				TotalProjectCount = totalProjectCount
			};

			return View(viewModel);
		}
    }


}
