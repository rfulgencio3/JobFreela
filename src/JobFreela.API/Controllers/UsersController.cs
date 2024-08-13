using JobFreela.Application.Commands.CreateUser;
using JobFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
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
        if (!ModelState.IsValid) 
        { 
            var messages = ModelState
                .SelectMany(m => m.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(messages);
        }

        await _mediator.Send(command);
        return Created();
    }
}
