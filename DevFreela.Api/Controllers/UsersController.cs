using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginCommand;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DevFreela.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UsersController : Controller
{
    protected readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand model)
    {
        CancellationToken cancellationToken = HttpContext.RequestAborted;
        long id = await _mediator.Send(model, cancellationToken);
        return Created(nameof(GetByIdAsync), id);
    }

    [HttpGet("{idUser}")]
    public async Task<IActionResult> GetByIdAsync(long idUser)
    {
        var query = new GetUserByIdQuery(idUser);
        var user = await _mediator.Send(query);
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand login)
    {
        var response = await _mediator.Send(login);
        return Ok(response);
    }
}
