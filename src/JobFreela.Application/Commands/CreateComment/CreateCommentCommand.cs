using MediatR;

namespace JobFreela.Application.Commands.CreateComment;

public class CreateCommentCommand : IRequest
{
    public CreateCommentCommand(int idProject)
    {
        IdProject = idProject;
    }

    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}
