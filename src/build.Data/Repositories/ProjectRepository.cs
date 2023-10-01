using build.Data.Context;
using build.Domain.Entities;

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
    }
}
