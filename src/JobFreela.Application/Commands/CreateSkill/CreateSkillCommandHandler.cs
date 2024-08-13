using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly ISkillRepository _repository;
    public CreateSkillCommandHandler(ISkillRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(
            request.Description,
            request.Experience
            );

        await _repository.AddAsync(skill);

        return skill.Id;
    }
}
