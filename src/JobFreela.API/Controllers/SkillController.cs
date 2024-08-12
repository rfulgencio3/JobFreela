using JobFreela.Application.Commands.CreateSkill;
using JobFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService _service;
    private readonly IMediator _mediator;
    public SkillController(ISkillService service, IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var skills = _service.GetAll();
        if (skills is null) { NotFound(); }

        return Ok(skills);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var skill = _service.GetById(id);
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
