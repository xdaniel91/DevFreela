using DevFreela.Application.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    public void Login(LoginInputModel loingModel);
}
