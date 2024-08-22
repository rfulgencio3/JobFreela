using JobFreela.Application.ViewModels;
using JobFreela.Core.Models;
using MediatR;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<PaginationResult<ProjectViewModel>>
{
    public GetAllProjectsQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get; set; }
    public int Page { get; set; }
}
