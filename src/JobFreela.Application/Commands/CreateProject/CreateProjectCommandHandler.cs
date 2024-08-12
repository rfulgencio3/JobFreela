using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly JobFreelaDbContext _context;
    public CreateProjectCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(
            request.Title,
            request.Description,
            request.IdClient,
            request.IdFreelancer,
            request.TotalCost
            );

        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();

        return project.Id;
    }
}
