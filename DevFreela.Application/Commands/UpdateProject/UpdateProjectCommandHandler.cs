using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject;
public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly DevFreelaDbContext _dbContext;

    public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectUpdate = await _dbContext.Projects.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        projectUpdate?.Update(request.Description, request.Title, request.TotalCost);
        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
