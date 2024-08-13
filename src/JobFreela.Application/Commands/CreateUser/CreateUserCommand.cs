using MediatR;

namespace JobFreela.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public DateTime BirthDate { get; private set; }
}
