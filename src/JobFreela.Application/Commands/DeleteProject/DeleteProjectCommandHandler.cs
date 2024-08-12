using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly JobFreelaDbContext _context;
    public DeleteProjectCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

        project.Cancel();
        await _context.SaveChangesAsync();
    }
}
