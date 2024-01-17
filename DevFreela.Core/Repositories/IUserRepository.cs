using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<long> InsertAsync(User user, CancellationToken cancellationToken);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash, CancellationToken cancellationToken);
}
