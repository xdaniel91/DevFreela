using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectUpdate = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);
        projectUpdate?.Update(request.Description, request.Title, request.TotalCost);

        await _projectRepository.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
