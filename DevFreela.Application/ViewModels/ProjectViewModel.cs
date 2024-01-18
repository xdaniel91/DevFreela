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
    public string ClientFullName { get; set; }
    public string FreelancerFullName { get; set; }

    public ProjectViewModel(Project project)
    {
        CreatedAt = project.CreatedAt;
        Description = project.Description;
        Status = project.Status;
        Title = project.Title;
        TotalCost = project.TotalCost;
        FreelancerFullName = $"{project.Freelancer?.FirstName}  {project.Freelancer?.LastName}";
        ClientFullName = $"{project.Client?.FirstName}  {project.Client?.LastName}";
    }
}
