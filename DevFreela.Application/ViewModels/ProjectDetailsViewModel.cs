using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;
public class ProjectDetailsViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long IdClient { get; set; }
    public long IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishAt { get; set; }

    public ProjectDetailsViewModel(Project p)
    {
        Title = p.Title;
        Description = p.Description;
        IdClient = p.IdClient;
        IdFreelancer = p.IdFreelancer;
        TotalCost = p.TotalCost;
        CreatedAt = p.CreatedAt;
        StartedAt = p.StartedAt;
        FinishAt = p.FinishAt;
    }

}
