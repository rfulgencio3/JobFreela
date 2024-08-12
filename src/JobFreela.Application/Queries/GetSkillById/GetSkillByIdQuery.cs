using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Queries.GetSkillById;

public class GetSkillByIdQuery : IRequest<SkillViewModel>
{
    public GetSkillByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
