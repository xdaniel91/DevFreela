using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, long>
{
    private readonly DevFreelaDbContext _context;

    public CreateProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Project projectInsert = new(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

        await _context.Projects.AddAsync(projectInsert, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return projectInsert.Id;
    }
}
