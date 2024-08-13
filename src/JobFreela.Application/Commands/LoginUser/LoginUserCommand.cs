using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Commands.LoginUser;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
}
