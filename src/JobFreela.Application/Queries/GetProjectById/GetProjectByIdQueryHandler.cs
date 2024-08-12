using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
{
    private readonly JobFreelaDbContext _context;
    public GetProjectByIdQueryHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FindAsync(request.Id);
        return new ProjectDetailsViewModel(
            project.Id, 
            project.Title, 
            project.Description, 
            project.TotalCost, 
            project.StartedAt, 
            project.FinishedAt, 
            project.Client.FullName, 
            project.Freelancer.FullName
            );
    }
}
