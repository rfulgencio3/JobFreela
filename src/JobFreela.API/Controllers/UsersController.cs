using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel createUser)
    {
        return CreatedAtAction(nameof(GetById), new {id = createUser.Id}, createUser);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent();
    }
}
