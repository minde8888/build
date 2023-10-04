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

        public async Task<List<Project>> GetAll()
        {
            return await _context.Project
                 .Include(p => p.Topics)
                     .ThenInclude(t => t.Subtopics)
                         .ThenInclude(s => s.Posts).ToListAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            project.DateUpdated = DateTime.UtcNow;

            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Project.
                Where(x => x.Id == id).FirstOrDefaultAsync();

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
