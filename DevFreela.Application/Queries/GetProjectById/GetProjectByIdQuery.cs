using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectViewModel>
{
    public long IdProject { get; set; }

    public GetProjectByIdQuery(long idProject)
    {
        IdProject = idProject;
    }
}
