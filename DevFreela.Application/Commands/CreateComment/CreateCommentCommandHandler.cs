using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, long>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<long> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ProjectComment comment = new(request.IdProject, request.Content, request.IdUser);
        return await _projectRepository.CreateCommentAsync(comment, cancellationToken);
    }
}
