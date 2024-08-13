using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly UserRepository _repository;
    public CreateUserCommandHandler(UserRepository repository)
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
