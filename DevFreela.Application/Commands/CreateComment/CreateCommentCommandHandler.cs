using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly DevFreelaDbContext _context;

    public CreateCommentCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ProjectComment comment = new(request.IdProject, request.Content, request.IdUser);
        await _context.Comments.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
