using MediatR;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public long IdProject { get; set; }

    public DeleteProjectCommand(long idProject)
    {
        IdProject = idProject;
    }
}
