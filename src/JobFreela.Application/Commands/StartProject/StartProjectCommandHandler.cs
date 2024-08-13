using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand>
{
    private readonly IProjectRepository _repository;
    public StartProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);
        project.Start();

        await _repository.SaveChangesAsync();
    }
}
