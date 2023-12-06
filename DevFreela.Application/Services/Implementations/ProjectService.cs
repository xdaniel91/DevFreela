using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevFreela.Application.Services.Implementations;
public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;

    public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("devfreela");
    }

    public void AddComment(CreateCommentInputModel comment)
    {
        var commentInsert = new ProjectComment(comment.IdProject, comment.Content, comment.IdUser);
        _dbContext.Comments.Add(commentInsert);
        _dbContext.SaveChanges();
    }

    public long Create(CreateProjectInputModel project)
    {
        var projectInsert = new Project(project.Title, project.Description, project.IdClient, project.IdFreelancer, project.TotalCost);

        _dbContext.Projects.Add(projectInsert);
        _dbContext.SaveChanges();
        return projectInsert.Id;
    }

    public void Delete(long id)
    {
        var projectRemove = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
        projectRemove?.Cancel();
        _dbContext.SaveChanges();
    }

    public void Finish(long id)
    {
        var projectFinish = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

        projectFinish?.Finish();
        _dbContext.SaveChanges();
    }

    public List<ProjectViewModel> GetAll()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        string sql = "select id, description from Skills;";
        return connection.Query<ProjectViewModel>(sql).ToList();
    }

    public ProjectViewModel GetById(long id)
    {
        var project = _dbContext.Projects.Include(x => x.Client).Include(x => x.Freelancer).SingleOrDefault(x => x.Id == id);

        if (project is null)
            return null;

        return new ProjectViewModel(project);
    }

    public void Start(long id)
    {
        var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
        project?.Start();
        _dbContext.SaveChanges();
    }

    public void Update(UpdateProjectInputModel project)
    {
        var projectUpdate = _dbContext.Projects.SingleOrDefault(x => x.Id == project.Id);
        projectUpdate?.Update(project.Description, project.Title, project.TotalCost);
        _dbContext.SaveChanges();

    }
}
