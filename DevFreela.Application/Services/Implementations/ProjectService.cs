using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
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
}
