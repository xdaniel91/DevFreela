namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
    public User User { get; private set; }
    public Skill Skill { get; private set; }
    public long IdUser { get; private set; }
    public long IdSkill { get; private set; }
}
