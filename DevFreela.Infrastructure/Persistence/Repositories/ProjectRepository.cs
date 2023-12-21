using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbSet<Project> Projects;

    public ProjectRepository(DevFreelaDbContext context)
    {
        Projects = context.Set<Project>();
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(CancellationToken cancellationToken)
    {
        return await Projects.ToListAsync(cancellationToken);
    }
}
