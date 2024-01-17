using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;

public class LoginResponse
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string BearerToken { get; set; }

    public LoginResponse(User user)
    {
        Email = user.Email;
        Username = user.Username;
    }
}
