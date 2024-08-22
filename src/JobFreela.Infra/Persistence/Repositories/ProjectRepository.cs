using JobFreela.Core.Entities;
using JobFreela.Core.Models;
using JobFreela.Core.Repositories;
using JobFreela.Infra.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private const int PAGE_SIZE = 2;
    private readonly JobFreelaDbContext _context;
    public ProjectRepository(JobFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<PaginationResult<Project>> GetAllAsync(string query, int page)
    {
        IQueryable<Project> projects = _context.Projects;

        if (!string.IsNullOrWhiteSpace(query))
        {
            projects = projects
                .Where(p =>
                    p.Title.Contains(query) ||
                    p.Description.Contains(query));
        }

        var paginationResult = await projects.GetPaged<Project>(page, PAGE_SIZE);
        return new JobFreela.Core.Models.PaginationResult<JobFreela.Core.Entities.Project>
        {
            Page = paginationResult.Page,
            PageSize = paginationResult.PageSize,
            ItensCount = paginationResult.ItensCount,
            TotalPages = paginationResult.TotalPages,
            Data = paginationResult.Data
        };
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
