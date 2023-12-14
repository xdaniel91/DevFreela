using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{

    protected readonly IUserService _userService;
    protected readonly IMediator _mediator;


    public UsersController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand model)
    {
        CancellationToken cancellationToken = HttpContext.RequestAborted;
        long id = await _mediator.Send(model, cancellationToken);
        return CreatedAtAction(nameof(GetById), id);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginInputModel login)
    {
        _userService.Login(login);
        return NoContent();
    }


}
