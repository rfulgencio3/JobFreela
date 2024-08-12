using MediatR;

namespace JobFreela.Application.Commands.StartProject;

public class StartProjectCommand : IRequest
{
    public int Id { get; set; }
}
