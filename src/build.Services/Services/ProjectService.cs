using AutoMapper;
using build.Data.Repositories;
using build.Domain.Entities;
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

        public async Task AddProjectAsync(Project project)
        {
            await _projectRepository.Add(project);
        }

        public async Task<ProjectDto> GetAsync(String id)
        {
            var project = await _projectRepository.Get(Guid.Parse(id));
            return _mapper.Map<ProjectDto>(project);
        }

        public void DeleteProjectAsync(Project project)
        {

        }
    }
}
