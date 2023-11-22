using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels;
public class ProjectViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public ProjectStatusEnum Status { get; set; }

    public ProjectViewModel(Project p)
    {
        CreatedAt = p.CreatedAt;
        Description = p.Description;
        Status = p.Status;
        Title = p.Title;
        TotalCost = p.TotalCost;
    }
}
