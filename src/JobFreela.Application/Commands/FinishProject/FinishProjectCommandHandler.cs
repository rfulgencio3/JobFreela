using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
{
    private readonly IProjectRepository _repository;
    public FinishProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);
        project.Finish();

        await _repository.SaveChangesAsync();
    }
}