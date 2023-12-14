using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;
public interface IUserService
{
    public void Login(LoginInputModel loingModel);
    public UserViewModel GetById(long id);
}
