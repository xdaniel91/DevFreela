using MediatR;

namespace DevFreela.Application.Commands.CreateProject;

/// <summary>
/// Have informations to create a project
/// </summary>
public class CreateProjectCommand : IRequest<long>
{

    public string Title { get; set; }
    public string Description { get; set; }
    public long IdFreelancer { get; set; }
    public long IdClient { get; set; }
    public decimal TotalCost { get; set; }

}
