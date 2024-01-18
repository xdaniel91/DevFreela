using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        string hashPassword = _authService.ComputeSha256Hash(request.Password);
        User? user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, hashPassword, cancellationToken);

        string token = _authService.GenerateJwtToken(user.Email, user.Role);
        return new LoginResponse(user, token);
    }
}
