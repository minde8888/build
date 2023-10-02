using build.Data.Context;
using build.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace build.Data.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> Get(Guid id)
        {
            return await _context.Project
                  .Include(p => p.Topics)
                      .ThenInclude(t => t.Subtopics)
                          .ThenInclude(s => s.Posts)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync();
        }
    }
}
