using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;
public class UserViewModel
{
    public string Email { get; set; }
    public string Username { get; set; }

    public UserViewModel(User user)
    {
        Email = user.Email;
        Username = user.Username;
    }
}
