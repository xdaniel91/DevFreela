using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectViewModel>>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Projects.Select(sl => new ProjectViewModel(sl)).AsEnumerable();
    }
}
