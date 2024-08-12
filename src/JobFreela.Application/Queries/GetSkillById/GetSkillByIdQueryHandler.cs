using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Queries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
{
    private readonly JobFreelaDbContext _context;
    public GetSkillByIdQueryHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _context.Skills.FindAsync(request.Id);
        return new SkillViewModel(skill.Id, skill.Description, skill.Experience, skill.CreatedAt);
    }
}

