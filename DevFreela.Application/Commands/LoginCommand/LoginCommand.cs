using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Commands.LoginCommand;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
