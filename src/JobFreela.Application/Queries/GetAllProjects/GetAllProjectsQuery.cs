using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{
    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
