using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
{
    private readonly JobFreelaDbContext _context;
    public FinishProjectCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == request.Id);

        project.Finish();
        await _context.SaveChangesAsync();
    }
}
