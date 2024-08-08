using JobFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobFreela.Infra.Persistence;

public class JobFreelaDbContext : DbContext
{
    public JobFreelaDbContext(DbContextOptions<JobFreelaDbContext> options) : base(options)
    { }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }
}
