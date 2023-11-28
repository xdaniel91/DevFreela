namespace DevFreela.Core.Entities;
public class User : BaseEntity
{
    public bool Active { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<Project> Projects { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    private User()
    {
    }

    public User(string usernName, string email, DateTime birthDate, string password)
    {
        Username = usernName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Projects = new();
        OwnedProjects = new();
        Active = true;
        Password = password;

    }
}
