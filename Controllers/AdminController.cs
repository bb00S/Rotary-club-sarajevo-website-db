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
        private readonly ITasksService _tasksService;

        public AdminController(IProjectService ps, IMemberService ms, ITasksService ts)
        {
            _projectService = ps;
            _memberService = ms;
            _tasksService = ts;
        }
        public async Task<IActionResult> Index()
        {
			int totalProjectCount = await _projectService.Count();
			int totalMemberCount = await _memberService.Count();
            int totalTasksCount = await _tasksService.Count();

            var viewModel = new AdminViewModel
            {
                TotalProjectCount = totalProjectCount,
                TotalMemberCount = totalMemberCount,
                TotalTasksCount = totalTasksCount
			};

			return View(viewModel);
		}
    }


}
