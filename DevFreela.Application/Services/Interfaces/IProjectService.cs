using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;
public interface IProjectService
{
    List<ProjectViewModel> GetAll();
    ProjectViewModel GetById(long id);
    long Create(CreateProjectInputModel project);
    void Update(UpdateProjectInputModel project);
    void Delete(long id);
    void Start(long id);
    void Finish(long id);
    void AddComment(CreateCommentInputModel comment);
}
