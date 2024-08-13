using JobFreela.Application.ViewModels;
using JobFreela.Core.Repositories;
using JobFreela.Core.Services;
using MediatR;

namespace JobFreela.Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _service;
    public LoginUserCommandHandler(IUserRepository repository, IAuthService service)
    {
        _repository = repository;
        _service = service;
    }
    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _service.ComputeSha256Hash(request.Password);
        var user = _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash).Result;

        if (user is null) { return null; }

        var token = _service.GenerateJwtToken(user.Email, user.Role);
        return new LoginUserViewModel(user.Email, token);
    }
}
