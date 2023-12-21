using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetUserById;
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
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand model)
    {
        CancellationToken cancellationToken = HttpContext.RequestAborted;
        long id = await _mediator.Send(model, cancellationToken);
        return Created(nameof(GetByIdAsync), id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long idUser)
    {
        var query = new GetUserByIdQuery(idUser);
        var user = await _mediator.Send(query);
        return Ok(user);
    }


    [HttpPost]
    [Route("login")]
    public IActionResult LoginAsync([FromBody] LoginInputModel login)
    {
        _userService.Login(login);
        return NoContent();
    }
}
