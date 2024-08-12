using MediatR;

namespace JobFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
