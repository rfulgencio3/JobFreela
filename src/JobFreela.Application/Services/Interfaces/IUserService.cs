using JobFreela.Application.ViewModels;

namespace JobFreela.Application.Services.Interfaces;

public interface IUserService
{
    UserViewModel GetUser(int id);
}
