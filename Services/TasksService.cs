using Azure;
using System.Linq;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;
using RotaryClub.Repositories;
using RotaryClub.ViewModels.Tasks;


namespace RotaryClub.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly ITasksService _tasksService;
		public TasksService(ITasksRepository tasksRepository)
		{
			_tasksRepository = tasksRepository;
		}
		public async Task<Status> Create(CreateTasksViewModel viewModel)
        {
            Tasks tasks = new()
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return await _tasksRepository.Create(tasks);
        }

        public async Task<Status> Delete(int id)
        {
            var tasks = await _tasksRepository.GetById(id);
            if (tasks == null)
                return new Status("Task not found");
           var status = await _tasksRepository.Delete(tasks);
            if (!status.Success)
                return status;

            return new Status();
        }

        public Task<IEnumerable<Tasks>> GetAll()
        {
            return _tasksRepository.GetAll();
        }

        public Task<Tasks> GetById(int id)
        {
            return _tasksRepository.GetById(id);
        }

        public Task<IEnumerable<Tasks>> GetLastThreeTasks()
        {
            return _tasksRepository.GetLastThreeTasks();
        }

        public async Task<Status> Update(int id, EditTasksViewModel viewModel)
        {
            var tasks = await _tasksRepository.GetById(id);

            tasks.Title = viewModel.Title;
            tasks.Content = viewModel.Content;
            tasks.UpdatedAt = DateTime.Now;
            return await _tasksRepository.Update(tasks);
        }

        public async Task<int> Count()
        {
            return await _tasksRepository.Count();
        }

    }
}
