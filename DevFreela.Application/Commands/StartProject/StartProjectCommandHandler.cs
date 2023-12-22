using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var projectStart = await _projectRepository.GetByIdAsync(request.IdProject, cancellationToken);
        projectStart?.Start();

        await _projectRepository.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
