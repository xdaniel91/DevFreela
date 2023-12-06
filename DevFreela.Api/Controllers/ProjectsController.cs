using DevFreela.Api.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimingOption _option;
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IOptions<OpeningTimingOption> option, IProjectService projectService, IMediator mediator)
        {
            _option = option.Value;
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
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            CancellationToken cancellationToken = HttpContext.RequestAborted;
            long id = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProjectInputModel model)
        {
            _projectService.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult CreateComment([FromBody] CreateCommentInputModel model)
        {
            _projectService.AddComment(model);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(long id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(long id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }
}