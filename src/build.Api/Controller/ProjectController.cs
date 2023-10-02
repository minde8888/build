using build.Domain.Entities;
using build.Services.Dtos;
using build.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace build.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService)); ;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProject([FromForm] Project project)
        {
            await _projectService.AddProjectAsync(project);
            return Ok();
        }

        [HttpGet]
        public async Task<ProjectDto> GetProject(String id)
        {
            return await _projectService.GetAsync(id);             
        }

        [HttpGet]
        public async Task<List<Project>> GetAllProject()
        {
            return null;
        }

        [HttpPut]
        public async Task<Project> UpdateProject()
        {
            return null;
        }

        [HttpDelete]
        public async Task<Project> DeleteProject()
        {
            return null;
        }
    }
}
