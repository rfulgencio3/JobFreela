using JobFreela.Application.Services.Interfaces;
using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;

namespace JobFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly JobFreelaDbContext _context;
    public UserService(JobFreelaDbContext context)
    {
        _context = context;
    }

    public UserViewModel GetUser(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user == null)
        {
            return null;
        }

        return new UserViewModel(user.FullName, user.Email, user.BirthDate);
    }
}
