using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;

public class LoginResponse
{
    public string Email { get; set; }
    public string BearerToken { get; set; }

    public LoginResponse(User user, string bearerToken)
    {
        Email = user.Email;
        BearerToken = bearerToken;
    }
}
