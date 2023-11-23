using Azure;
using RotaryClub.Data;
using RotaryClub.Interfaces;
using RotaryClub.Models;
using RotaryClub.ViewModels.Project;

namespace RotaryClub.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPhotoService _photoService;

        public ProjectService(IProjectRepository projectRepository, IPhotoService photoService)
        {
            _projectRepository = projectRepository;
            _photoService = photoService;
        }

        public async Task<Status> Create(CreateProjectViewModel viewModel)
        {
            var photoPath = await _photoService.Create(viewModel.Photo, "projects");
            if (photoPath == null)
                return new Status("Photo upload failed");
            Project project = new()
            {
                Title = viewModel.Title,
                SubTitle = viewModel.SubTitle,
                PhotoUrl = photoPath,
                Content = viewModel.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return await _projectRepository.Create(project);
        }

        public async Task<Status> Delete(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null)
                return new Status("Project not found");

            var status = _photoService.Delete(project.PhotoUrl);
            if (!status.Success)
                return status;

            status = await _projectRepository.Delete(project);
            if (!status.Success)
                return status;

            return new Status();
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Task<Project> GetById(int id)
        {
            return _projectRepository.GetById(id);
        }

        public Task<IEnumerable<Project>> GetLastThreeProjects()
        {
            return _projectRepository.GetLastThreeProjects();
        }

        public async Task<Status> Update(int id, EditProjectViewModel viewModel)
        {
            var project = await _projectRepository.GetById(id);
            if (viewModel.Photo != null)
            {
                _photoService.Delete(project.PhotoUrl);
                project.PhotoUrl = await _photoService.Create(viewModel.Photo, "projects");
            }
            project.Title = viewModel.Title;
            project.SubTitle = viewModel.SubTitle; 
            project.Content = viewModel.Content;
            project.UpdatedAt = DateTime.Now;
            return await _projectRepository.Update(project);
        }
    }
}
