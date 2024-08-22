using JobFreela.Application.ViewModels;
using JobFreela.Core.Models;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PaginationResult<ProjectViewModel>>
{
    private readonly IProjectRepository _repository;
    public GetAllProjectsQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<PaginationResult<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var paginationProjects = await _repository.GetAllAsync(request.Query, request.Page);

        var projectsViewModel = paginationProjects
            .Data
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
            .ToList();

        return new PaginationResult<ProjectViewModel>(
            paginationProjects.Page,
            paginationProjects.TotalPages,
            paginationProjects.PageSize,
            paginationProjects.ItensCount,
            projectsViewModel
            );
    }
}
