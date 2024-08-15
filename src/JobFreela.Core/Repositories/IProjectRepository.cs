using JobFreela.Core.Entities;

namespace JobFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync(string query);
    Task<Project> GetByIdAsync(int id);
    Task AddAsync(Project project);
    Task SaveChangesAsync();
}
