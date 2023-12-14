using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly DevFreelaDbContext _dbContext;

    public CreateUserCommandHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        User user = new(request.Username, request.Email, request.BirthDate, request.Password);
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
