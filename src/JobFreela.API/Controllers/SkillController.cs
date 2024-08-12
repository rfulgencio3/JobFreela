using JobFreela.Application.Commands.CreateSkill;
using JobFreela.Application.Queries.GetAllSkills;
using JobFreela.Application.Queries.GetSkillById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly IMediator _mediator;
    public SkillController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var skills = await _mediator.Send(new GetAllSkillsQuery());

        if (skills is null) { NotFound(); }

        return Ok(skills);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var query = new GetSkillByIdQuery(id);
        var skill = _mediator.Send(query);

        if (skill is null) { NotFound(); }

        return Ok(skill);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
    {
        if (command.Description.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
}
