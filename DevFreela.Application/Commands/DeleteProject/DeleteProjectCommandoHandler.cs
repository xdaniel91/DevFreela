using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandoHandler : IRequestHandler<DeleteProjectCommand>
{

    private readonly DevFreelaDbContext _dbContext;

    public DeleteProjectCommandoHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var projectDelete = await _dbContext.Projects.SingleOrDefaultAsync(e => e.Id == request.IdProject);
        projectDelete?.Cancel();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
