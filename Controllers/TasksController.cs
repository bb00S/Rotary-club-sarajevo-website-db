using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.Services;
using RotaryClub.ViewModels.Project;
using RotaryClub.ViewModels.Tasks;

namespace RotaryClub.Controllers
{

    public class TasksController : Controller
    {

        private readonly ITasksService _tasksService;

		public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

		public async Task<IActionResult> Index()
		{
			var tasks = await _tasksService.GetAll();

			return View(tasks);
		}

		public async Task<IActionResult> TasksIndex()
        {
            var tasks = await _tasksService.GetAll();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createTasksVM = new CreateTasksViewModel();
            return View(createTasksVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTasksViewModel createTasksVM)
        {
            if (!ModelState.IsValid)
                return View(createTasksVM);

            var response = await _tasksService.Create(createTasksVM);
            if (response.Success)
                return RedirectToAction("TasksIndex");

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tasks = await _tasksService.GetById(id);
            ViewBag.Id = id;
            return View(tasks.ToEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTasksViewModel editTasksVM)
        {
            if (!ModelState.IsValid)
                return View(editTasksVM);
            var status = await _tasksService.Update(id, editTasksVM);
            if (status.Success)
                return RedirectToAction("TasksIndex");
            return BadRequest(status.ErrorMessage);
        }

        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tasksService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<ActionResult> LatestTasks()
        {
            var tasks = await _tasksService.GetLastThreeTasks();
            return PartialView("_AdminTasksPartial", tasks);
        }
    }
}
