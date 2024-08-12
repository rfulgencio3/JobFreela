using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
{
    private readonly JobFreelaDbContext _context;
    public GetAllSkillsQueryHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = _context.Skills;

        var skillsViewModel = await skills
            .Select(s => new SkillViewModel(s.Id, s.Description, s.Experience, s.CreatedAt))
            .ToListAsync();

        return skillsViewModel;

    }
}
