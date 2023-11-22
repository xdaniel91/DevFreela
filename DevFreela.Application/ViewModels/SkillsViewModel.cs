using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;
public class SkillsViewModel
{
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Id { get; set; }

    public SkillsViewModel(Skill skill)
    {
        Description = skill.Description;
        CreatedAt = skill.CreatedAt;
        Id = skill.Id;
    }
}
