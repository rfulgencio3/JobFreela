using JobFreela.Core.Entities;

namespace JobFreela.Infra.Persistence;

public class JobFreelaDbContext
{
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }
}
