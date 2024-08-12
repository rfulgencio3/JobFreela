using MediatR;

namespace JobFreela.Application.Commands.StartProject;

public class StartProjectCommand : IRequest
{
    public StartProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
