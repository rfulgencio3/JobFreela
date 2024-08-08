using JobFreela.Application.Services.Interfaces;
using JobFreela.Application.ViewModels;
using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;

namespace JobFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly JobFreelaDbContext _context;
    public SkillService(JobFreelaDbContext context)
    {
        _context = context;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _context.Skills;
        return skills.Select(p => new SkillViewModel(p.Id, p.Description, p.Experience, p.CreatedAt))
            .ToList();
    }

    public SkillViewModel GetById(int id)
    {
        var skill = _context.Skills.SingleOrDefault(p => p.Id == id);
        var skillViewModel = new SkillViewModel(
            skill.Id,
            skill.Description,
            skill.Experience,
            skill.CreatedAt);

        return skillViewModel;
    }
}
