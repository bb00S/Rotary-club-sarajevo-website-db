using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.ViewModels.Project;

namespace RotaryClub.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var project = await _projectService.GetAll();
            return View(project);
        }

        public async Task<IActionResult> AdminIndex()
        {
            var project = await _projectService.GetAll();
            return View(project);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createProjectVM = new CreateProjectViewModel();
            return View(createProjectVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel createProjectVM)
        {
            if (!ModelState.IsValid)
                return View(createProjectVM);

            var response = await _projectService.Create(createProjectVM);
            if (response.Success)
                return RedirectToAction("Index");

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetById(id);
            ViewBag.Id = id;
            return View(project.ToEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProjectViewModel editProjectVM)
        {
            if (!ModelState.IsValid)
                return View(editProjectVM);
            var status = await _projectService.Update(id, editProjectVM);
            if (status.Success)
                return RedirectToAction("Index");
            return BadRequest(status.ErrorMessage);
        }

        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");
            return BadRequest(result.ErrorMessage);
        }


        [HttpGet]
        public async Task<ActionResult> LatestProjects()
        {
            var projects = await _projectService.GetLastThreeProjects();
            return PartialView("_HomeProjectsPartial", projects);
        }
    }
}
