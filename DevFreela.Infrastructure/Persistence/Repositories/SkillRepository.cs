using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DbSet<Skill> Skills;

    public SkillRepository(DevFreelaDbContext context)
    {
        Skills = context.Set<Skill>();
    }

    public async Task<IEnumerable<Skill>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Skills.ToListAsync(cancellationToken);
    }
}
