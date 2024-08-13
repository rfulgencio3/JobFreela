using JobFreela.Core.Entities;

namespace JobFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<List<Skill>> GetAllAsync();
    Task<Skill> GetByIdAsync(int id);
    Task AddAsync(Skill skill);
}
