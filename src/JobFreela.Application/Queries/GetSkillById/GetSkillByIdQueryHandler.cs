using JobFreela.Application.ViewModels;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Queries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
{
    private readonly ISkillRepository _repository;
    public GetSkillByIdQueryHandler(ISkillRepository repository)
    {
        _repository = repository;
    }
    public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetByIdAsync(request.Id);

        return new SkillViewModel(skill.Id, skill.Description, skill.Experience, skill.CreatedAt);
    }
}

