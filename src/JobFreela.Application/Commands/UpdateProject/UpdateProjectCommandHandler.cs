using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly JobFreelaDbContext _context;
    public UpdateProjectCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

        project.Update(request.Title, request.Description, request.TotalCost);

        await _context.SaveChangesAsync();
    }
}
