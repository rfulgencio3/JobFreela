using MediatR;

namespace JobFreela.Application.Commands.CreateComment;

public class CreateCommentCommand : IRequest
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}
