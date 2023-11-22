using DevFreela.Api.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
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

        public ProjectsController(IOptions<OpeningTimingOption> option, IProjectService projectService)
        {
            _option = option.Value;
            _projectService = projectService;
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
        public IActionResult Create([FromBody] CreateProjectInputModel model)
        {
            if (model.Title.Length > 50)
                return BadRequest();

            var id = _projectService.Create(model);

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
        public IActionResult CreateComment([FromBody] CreateCommentoInputModel model)
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