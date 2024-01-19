namespace DevFreela.Core.Entities;

public class ProjectComment : BaseEntity
{
    public long IdProjet { get; private set; }
    public Project Project { get; private set; }
    public string Content { get; private set; }
    public long IdUser { get; private set; }
    public User User { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public ProjectComment(long idProjet, string content, long idUser)
    {
        IdProjet = idProjet;
        Content = content;
        IdUser = idUser;
        CreatedAt = DateTime.Now;
    }
}
