using JobFreela.Application.ViewModels;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
{
    private readonly ISkillRepository _repository;
    public GetAllSkillsQueryHandler(ISkillRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _repository.GetAllAsync();

        var skillsViewModel = skills
            .Select(s => new SkillViewModel(s.Id, s.Description, s.Experience, s.CreatedAt))
            .ToList();

        return skillsViewModel;

    }
}
