using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;
public interface IProjectService
{
    List<ProjectViewModel> GetAll();
    ProjectViewModel GetById(long id);
}
