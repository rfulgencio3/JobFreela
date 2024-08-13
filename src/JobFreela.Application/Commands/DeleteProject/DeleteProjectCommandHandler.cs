using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _repository;
    public DeleteProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);
        project.Cancel();

        await _repository.SaveChangesAsync();
    }
}
