using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var project = _projectService.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand request)
        {
            long id = await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);

            return CreatedAtAction(nameof(GetById), id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectCommand request)
        {
            await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult CreateComment([FromBody] CreateCommentCommand request)
        {
            _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start([FromBody] StartProjectCommand request)
        {
            await _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish([FromBody] FinishProjectCommand request)
        {
            _mediator.Send(request, cancellationToken: HttpContext.RequestAborted);
            return NoContent();
        }
    }
}