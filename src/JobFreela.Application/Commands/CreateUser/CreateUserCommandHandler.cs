using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using JobFreela.Core.Services;
using MediatR;

namespace JobFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _service;
    public CreateUserCommandHandler(IUserRepository repository, IAuthService service)
    {
        _repository = repository;
        _service = service;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _service.ComputeSha256Hash(request.Password);
        var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

        await _repository.AddAsync(user);
        
        return user.Id;
    }
}
