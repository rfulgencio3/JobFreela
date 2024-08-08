using JobFreela.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
        
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateUserInputModel createUser)
    {
        return CreatedAtAction(nameof(GetById), new {id = createUser.Id}, createUser);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginInputModel login)
    {
        return NoContent();
    }
}
