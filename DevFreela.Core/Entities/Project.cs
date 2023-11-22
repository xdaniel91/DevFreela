using DevFreela.Core.Enums;
using DevFreela.Core.Exceptions;

namespace DevFreela.Core.Entities;
public class Project : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; private set; }
    public long IdClient { get; private set; }
    public long IdFreelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
    public User Client { get; private set; }
    public User Freelancer { get; private set; }

    public Project(string title, string description, long idClient, long idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        CreatedAt = DateTime.Now;
        Comments = new();
        Status = ProjectStatusEnum.Created;
    }

    public void Cancel()
    {
        if (Status is ProjectStatusEnum.InProgress or ProjectStatusEnum.Finished)
            throw new DomainException("Is not possible cancell a project in progress or finished.");

        Status = ProjectStatusEnum.Cancelled;
    }

    public void Finish()
    {
        if (Status is ProjectStatusEnum.Suspended or ProjectStatusEnum.Cancelled or ProjectStatusEnum.Finished)
            throw new DomainException($"Is not possible finished a project because it is {Status}");

        FinishAt = DateTime.Now;
        Status = ProjectStatusEnum.Finished;
    }

    public void Start()
    {
        if (Status != ProjectStatusEnum.Created)
            throw new DomainException("Is only possible start a project was created");

        StartedAt = DateTime.Now;
        Status = ProjectStatusEnum.InProgress;
    }

    public void Update(string description, string title, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}