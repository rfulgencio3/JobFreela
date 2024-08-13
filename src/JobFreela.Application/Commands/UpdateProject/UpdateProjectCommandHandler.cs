using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _repository;
    public UpdateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);

        project.Update(request.Title, request.Description, request.TotalCost);

        await _repository.SaveChangesAsync();
    }
}
