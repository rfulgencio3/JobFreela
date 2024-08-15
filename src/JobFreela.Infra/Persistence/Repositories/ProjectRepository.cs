using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly JobFreelaDbContext _context;
    public ProjectRepository(JobFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllAsync(string query)
    {
        IQueryable<Project> projects = _context.Projects;

        if (!string.IsNullOrWhiteSpace(query))
        {
            projects = projects
                .Where(p =>
                    p.Title.Contains(query) ||
                    p.Description.Contains(query));
        }

        return await projects.ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
