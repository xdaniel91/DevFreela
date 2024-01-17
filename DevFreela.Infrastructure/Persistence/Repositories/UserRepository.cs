using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> Users;
    private readonly DevFreelaDbContext _context;

    public UserRepository(DevFreelaDbContext context)
    {
        _context = context;
        Users = _context.Set<User>();
    }

    public async Task<User?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await Users.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<long> InsertAsync(User user, CancellationToken cancellationToken)
    {
        var insertedUser = await Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return insertedUser.Entity.Id;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash, CancellationToken cancellationToken)
    {
        return await Users.SingleOrDefaultAsync(e => e.Email == email && e.Password == passwordHash, cancellationToken);
    }
}
