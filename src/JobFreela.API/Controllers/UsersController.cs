using JobFreela.Application.Commands.CreateUser;
using JobFreela.Application.Commands.LoginUser;
using JobFreela.Application.Queries.GetUserById;
using JobFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var viewModel = await _mediator.Send(command);
        if (viewModel == null) { return BadRequest(); }

        return Ok(viewModel);
    }
}
