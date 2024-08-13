using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IProjectCommentRepository _repository;
    public CreateCommentCommandHandler(IProjectCommentRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(
            request.Content,
            request.IdProject,
            request.IdUser);

        await _repository.AddAsync(comment);
    }
}
