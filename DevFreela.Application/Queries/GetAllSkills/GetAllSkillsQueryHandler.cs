using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillsViewModel>>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SkillsViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Skills.Select(s => new SkillsViewModel(s)).ToListAsync(cancellationToken);
    }
}
