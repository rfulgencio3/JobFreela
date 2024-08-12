using JobFreela.Application.InputModels;
using JobFreela.Application.ViewModels;

namespace JobFreela.Application.Services.Interfaces;

public interface IUserService
{
    int Create(CreateUserInputModel inputModel);
    UserViewModel GetUser(int id);
}
