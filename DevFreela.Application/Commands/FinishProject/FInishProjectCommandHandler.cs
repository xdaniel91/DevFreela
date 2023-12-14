using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.FinishProject;

public class FInishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
{
    private readonly DevFreelaDbContext _dbContext;

    public FInishProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _dbContext = devFreelaDbContext;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var projectFinish = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == request.IdProject, cancellationToken);
        projectFinish?.Finish();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
