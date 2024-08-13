using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _repository;
    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;   
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FullName, request.Email, request.BirthDate);

        await _repository.AddAsync(user);
        
        return user.Id;
    }
}
