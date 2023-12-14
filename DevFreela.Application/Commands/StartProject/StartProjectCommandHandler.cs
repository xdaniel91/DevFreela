using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand>
{
    private readonly DevFreelaDbContext _dbContext;

    public StartProjectCommandHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var projectStart = await _dbContext.Projects.SingleOrDefaultAsync(e => e.Id == request.IdProject, cancellationToken);
        projectStart?.Start();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
