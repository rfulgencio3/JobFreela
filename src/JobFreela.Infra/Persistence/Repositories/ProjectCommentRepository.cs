using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence.Repositories;

public class ProjectCommentRepository : IProjectCommentRepository
{
    private readonly JobFreelaDbContext _context;
    public ProjectCommentRepository(JobFreelaDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProjectComment projectComment)
    {
        await _context.ProjectComments.AddAsync(projectComment);
        await _context.SaveChangesAsync();

    }
}