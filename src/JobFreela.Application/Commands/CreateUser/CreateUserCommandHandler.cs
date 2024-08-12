using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly JobFreelaDbContext _context;
    public CreateUserCommandHandler(JobFreelaDbContext context)
    {
        _context = context;   
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FullName, request.Email, request.BirthDate);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}
