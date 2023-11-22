using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillService
{
    public List<SkillsViewModel> GetAll();
}
