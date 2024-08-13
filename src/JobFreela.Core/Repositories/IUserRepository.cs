using JobFreela.Core.Entities;

namespace JobFreela.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
}
