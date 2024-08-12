using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly JobFreelaDbContext _context;
    public GetAllProjectsQueryHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = _context.Projects;

        var projectsViewModel = await projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
            .ToListAsync();

        return projectsViewModel;
    }
}
