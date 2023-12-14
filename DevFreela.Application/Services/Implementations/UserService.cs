using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Exceptions;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _dbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public UserViewModel GetById(long id)
    {
        return new UserViewModel(_dbContext.Users.FirstOrDefault(x => x.Id == id));
    }

    public void Login(LoginInputModel loginModel)
    {
        bool sucess = _dbContext.Users.Any(u => u.Password == loginModel.Password && u.Username == loginModel.Username);

        if (sucess)
            return;

        throw new DomainException("User with this credentials not founded.");
    }
}
