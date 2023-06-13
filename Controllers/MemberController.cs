using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createMemberVM = new CreateMemberViewModel();
            return View(createMemberVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberViewModel createMemberVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createMemberVM);
            }

            var response = await _memberService.Create(createMemberVM);
            if (response.Success)
                return RedirectToAction("Index");
            return BadRequest(response.ErrorMessage);
        }
    }
}
