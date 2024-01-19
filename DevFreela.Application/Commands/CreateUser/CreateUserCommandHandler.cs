using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string password = _authService.ComputeSha256Hash(request.Password);
        User user = new(request.FirstName, request.LastName, request.Email, request.BirthDate, password, request.Role);
        return await _userRepository.InsertAsync(user, cancellationToken);
    }
}
