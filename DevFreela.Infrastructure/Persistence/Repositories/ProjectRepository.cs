using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbSet<Project> Projects;
    private readonly DbSet<ProjectComment> Comments;
    private readonly DevFreelaDbContext _context;

    public ProjectRepository(DevFreelaDbContext context)
    {
        _context = context;
        Projects = _context.Set<Project>();
        Comments = _context.Set<ProjectComment>();
    }

    public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Projects.ToListAsync(cancellationToken);
    }

    public async Task<Project?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await Projects.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<long> InsertAsync(Project projectInsert, CancellationToken cancellationToken)
    {
        var insertedProject = await Projects.AddAsync(projectInsert, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return insertedProject.Entity.Id;
    }

    public async Task<long> CreateCommentAsync(ProjectComment comment, CancellationToken cancellationToken)
    {
        var insertedComment = await Comments.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return insertedComment.Entity.Id;
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
