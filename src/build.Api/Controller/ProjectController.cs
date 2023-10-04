using build.Domain.Entities;
using build.Services.Dtos;
using build.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
        public async Task<IActionResult> AddNewProject(ProjectDto project)
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
            return await _projectService.GetAllAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectDto project)
        {
            await _projectService.UpdateProductAsync(project);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProject(string id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok();
        }
    }
}
