using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(e => e.Id == request.IdUser, cancellationToken);

        if (user is null)
            throw new Exception($"User with id {request.IdUser} not found.");

        return new UserViewModel(user);
    }
}
