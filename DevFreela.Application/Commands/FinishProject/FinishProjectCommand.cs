using MediatR;

namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommand : IRequest
{
    public long IdProject { get; set; }

    public FinishProjectCommand(long idProject)
    {
        IdProject = idProject;
    }
}
