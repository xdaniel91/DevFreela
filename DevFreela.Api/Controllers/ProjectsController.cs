using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace DevFreela.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjectsAsync()
    {
        var request = new GetAllProjectsQuery();
        var projects = await _mediator.Send(request, HttpContext.RequestAborted);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectByIdAsync(long id)
    {
        var query = new GetProjectByIdQuery(id);
        var result = await _mediator.Send(query, HttpContext.RequestAborted);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectCommand request)
    {
        long id = await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);

        return Created(nameof(GetProjectByIdAsync), id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync([FromBody] UpdateProjectCommand request)
    {
        await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpDelete("{idProject}")]
    public async Task<IActionResult> DeleteProjectAsync(long idProject)
    {
        var requset = new DeleteProjectCommand(idProject);
        await _mediator.Send(requset);
        return NoContent();
    }

    [HttpPost("comments")]
    public IActionResult CreateCommentAsync([FromBody] CreateCommentCommand request)
    {
        _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPut("{idProject}/start")]
    public async Task<IActionResult> StartProjectAsync(long idProject)
    {
        var request = new StartProjectCommand(idProject);
        await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPut("{idProject}/finish")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> FinishProjectAsync(long idProject)
    {
        var request = new FinishProjectCommand(idProject);
        await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpGet("pesssoas")]
    [OutputCache(Duration = 5)]
    public async Task<IActionResult> ObterPessoasAsync()
    {
        await Task.Delay(2500);
        return Ok(ListaPessoas.ObterListaPessoas());
    }
}

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string CPF { get; set; }
}

public static class ListaPessoas
{
    public static List<Pessoa> ObterListaPessoas()
    {
        List<Pessoa> pessoas = new List<Pessoa>();

        for (int i = 1; i <= 50; i++)
        {
            pessoas.Add(new Pessoa
            {
                Nome = $"Pessoa{i}",
                Idade = 25 + i,
                CPF = GerarCPF()
            });
        }

        return pessoas;
    }

    private static string GerarCPF()
    {
        Random random = new Random();
        return $"{random.Next(100, 999)}.{random.Next(100, 999)}.{random.Next(100, 999)}-{random.Next(10, 99)}";
    }
}
