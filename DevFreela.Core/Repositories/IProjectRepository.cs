using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken);
    Task<Project?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<long> InsertAsync(Project projectInsert, CancellationToken cancellationToken);
    Task<long> CreateCommentAsync(ProjectComment comment, CancellationToken cancellationToken);
    Task<bool> CommitAsync(CancellationToken cancellationToken);
}
