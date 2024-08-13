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

    public async Task<List<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
    }
}
