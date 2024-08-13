using JobFreela.Core.Entities;

namespace JobFreela.Core.Repositories;

public interface IProjectCommentRepository
{
    Task AddAsync(ProjectComment projectComment);
}
