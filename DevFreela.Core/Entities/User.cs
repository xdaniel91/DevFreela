namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public bool Active { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserSkill> Skills { get; private set; } = new();
    public List<Project> Projects { get; private set; } = new();
    public List<Project> OwnedProjects { get; private set; } = new();
    public List<ProjectComment> Comments { get; private set; } = new();

    public User(string firstName, string lastName, string email, DateTime birthDate, string password, string role)
    {
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.UtcNow;
        Active = true;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }

    private User()
    {
        
    }
}
