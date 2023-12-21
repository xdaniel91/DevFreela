using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.SingleOrDefaultAsync(e => e.Id == request.IdProject, cancellationToken);

        if (project is null)
            throw new Exception($"project with id {request.IdProject} not found.");

        return new ProjectViewModel(project);
    }
}
