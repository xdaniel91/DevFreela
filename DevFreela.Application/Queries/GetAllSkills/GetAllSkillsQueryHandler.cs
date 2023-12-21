using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillsViewModel>>
{
    private readonly ISkillRepository _skillRepository;

    public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<SkillsViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _skillRepository.GetAllAsync(cancellationToken);
        return skills.Select(sl => new SkillsViewModel(sl));
    }
}
