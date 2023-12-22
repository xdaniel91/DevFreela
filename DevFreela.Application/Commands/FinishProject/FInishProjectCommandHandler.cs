using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject;

public class FInishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public FInishProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var projectFinish = await _projectRepository.GetByIdAsync(request.IdProject, cancellationToken);
        projectFinish?.Finish();

        await _projectRepository.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
