using JobFreela.Core.Entities;

namespace JobFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(int id);
}
