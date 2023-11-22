using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{

    protected IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserInputModel model)
    {
        var id = _userService.Create(model);
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
