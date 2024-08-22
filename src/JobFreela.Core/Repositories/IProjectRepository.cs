using JobFreela.Core.Entities;
using JobFreela.Core.Models;

namespace JobFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<PaginationResult<Project>> GetAllAsync(string query, int page = 1);
    Task<Project> GetByIdAsync(int id);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
}
