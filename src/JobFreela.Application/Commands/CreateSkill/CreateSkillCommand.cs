using MediatR;

namespace JobFreela.Application.Commands.CreateSkill;

public class CreateSkillCommand : IRequest<int>
{
    public string Description { get; set; }
    public int Experience { get; set; }
}
