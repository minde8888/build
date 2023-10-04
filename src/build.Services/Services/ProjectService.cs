using AutoMapper;
using build.Data.Repositories;
using build.Domain.Entities;
using build.Domain.Exceptions;
using build.Services.Dtos;

namespace build.Services.Services
{
    public class ProjectService
    {
        private readonly IMapper _mapper;
        private readonly ProjectRepository _projectRepository;
        public ProjectService(IMapper mapper, ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddProjectAsync(ProjectDto project)
        {
            var projectDto = _mapper.Map<Project>(project);
            await _projectRepository.Add(projectDto);
        }

        public async Task<ProjectDto> GetAsync(String id)
        {
            var project = await _projectRepository.Get(Guid.Parse(id));
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var project = await _projectRepository.GetAll();

            return project;
        }

        public async Task UpdateProductAsync(ProjectDto project)
        {
            if (project == null)
                throw new ObjectNullException("Project can't by null");

            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProjectAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new StringNullException("Product id can't by null");
            Guid newId = new(id);
            await _projectRepository.DeleteAsync(newId);
        }
    }
}
