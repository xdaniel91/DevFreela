using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> FinishProjectAsync(long idProject)
        {
            var request = new FinishProjectCommand(idProject);
            await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
            return NoContent();
        }
    }
}