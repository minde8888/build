using build.Domain.Entities;
using build.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace build.Api.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService)); ;
        }

        public async Task<IActionResult> AddNewProject([FromForm] Project project)
        {
            await _projectService.AddProjectAsync(project);
            return Ok();
        }
    }
}
