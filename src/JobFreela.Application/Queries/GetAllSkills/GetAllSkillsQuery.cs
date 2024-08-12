using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
{
}
