using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;
public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;

    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SkillsViewModel> GetAll()
    {
        return _dbContext.Skills.Select(s => new SkillsViewModel(s)).ToList();
    }
}
