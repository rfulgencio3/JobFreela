using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly JobFreelaDbContext _context;
    public CreateSkillCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(
            request.Description,
            request.Experience
            );

        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();

        return skill.Id;
    }
}
