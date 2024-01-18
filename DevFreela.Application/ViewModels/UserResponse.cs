using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;

public class UserResponse
{
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public UserResponse(User user)
    {
        BirthDate = user.BirthDate;
        CreatedAt = user.CreatedAt;
        Active = user.Active;
        Email = user.Email;
    }
}
