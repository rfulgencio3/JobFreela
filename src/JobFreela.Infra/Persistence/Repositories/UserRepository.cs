using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly JobFreelaDbContext _context;
    public UserRepository(JobFreelaDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
}
