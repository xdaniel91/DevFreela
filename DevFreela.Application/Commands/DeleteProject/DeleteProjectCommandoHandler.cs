using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandoHandler : IRequestHandler<DeleteProjectCommand>
{

    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandoHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var projectDelete = await _projectRepository.GetByIdAsync(request.IdProject, cancellationToken);
        projectDelete?.Cancel();

        await _projectRepository.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
