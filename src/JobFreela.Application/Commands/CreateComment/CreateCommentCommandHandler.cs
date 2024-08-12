using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly JobFreelaDbContext _context;
    public CreateCommentCommandHandler(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(
            request.Content,
            request.IdProject,
            request.IdUser);

        await _context.ProjectComments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }
}
