using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand>
{
    private readonly JobFreelaDbContext _context;
    public StartProjectCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

        project.Start();
        await _context.SaveChangesAsync();
    }
}
