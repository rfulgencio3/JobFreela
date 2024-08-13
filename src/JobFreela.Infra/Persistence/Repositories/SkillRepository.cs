using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly JobFreelaDbContext _context;
    public SkillRepository(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<List<Skill>> GetAllAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task<Skill> GetByIdAsync(int id)
    {
        return await _context.Skills.SingleOrDefaultAsync(s => s.Id == id);
    }
}
