using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.ViewModels.Member;

namespace RotaryClub.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var members = await _memberService.GetAll();
            return View(members);
        }

        [AllowAnonymous]
        public async Task<IActionResult> IndexHomeAsync()
        {
            var members = await _memberService.GetAll();
            return View(members);
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
                return View(createMemberVM);

            var response = await _memberService.Create(createMemberVM);
            if (response.Success)
                return RedirectToAction("Index");
            
            return BadRequest(response.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberService.GetById(id);
            ViewBag.Id = id;
            return View(member.ToEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMemberViewModel editMemberVM)
        {
            if(!ModelState.IsValid)
                return View(editMemberVM);
            var status = await _memberService.Update(id, editMemberVM);
            if (status.Success)
                return RedirectToAction("Index");
            return BadRequest(status.ErrorMessage);          
        }


        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var member = await _memberService.GetById(id);
            if (member == null)
                return NotFound();
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memberService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");
            return BadRequest(result.ErrorMessage);
        }
    }
}
