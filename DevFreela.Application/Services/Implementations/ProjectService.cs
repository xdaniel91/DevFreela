using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;
public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddComment(CreateCommentoInputModel comment)
    {
        var commentInsert = new ProjectComment(comment.IdProject, comment.Content, comment.IdUser);
        _dbContext.Comments.Add(commentInsert);
    }

    public long Create(CreateProjectInputModel project)
    {
        var projectInsert = new Project(project.Title, project.Description, project.IdClient, project.IdFreelancer, project.TotalCost);

        _dbContext.Projects.Add(projectInsert);
        return projectInsert.Id;
    }

    public void Delete(long id)
    {
        var projectRemove = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

        projectRemove?.Cancel();
    }

    public void Finish(long id)
    {
        var projectFinish = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

        projectFinish?.Finish();
    }

    public List<ProjectViewModel> GetAll()
    {
        return _dbContext.Projects.Select(p => new ProjectViewModel(p)).ToList();
    }

    public ProjectViewModel GetById(long id)
    {
        var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

        if (project is null)
            return null;

        return new ProjectViewModel(project);
    }

    public void Start(long id)
    {
        var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
        project?.Start();
    }

    public void Update(UpdateProjectInputModel project)
    {
        var projectUpdate = _dbContext.Projects.SingleOrDefault(x => x.Id == project.Id);
        projectUpdate?.Update(project.Description, project.Title, project.TotalCost);

    }
}
