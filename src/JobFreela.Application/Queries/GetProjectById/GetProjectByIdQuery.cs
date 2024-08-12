using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
