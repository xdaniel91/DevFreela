using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllAsync(CancellationToken cancellationToken);
}
