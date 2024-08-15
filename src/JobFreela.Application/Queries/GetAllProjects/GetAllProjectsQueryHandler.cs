using JobFreela.Application.ViewModels;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly IProjectRepository _repository;
    public GetAllProjectsQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync(request.Query);

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }
}
