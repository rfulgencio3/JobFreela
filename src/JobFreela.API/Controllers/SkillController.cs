using JobFreela.Application.InputModels;
using JobFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService _service;
    public SkillController(ISkillService service)
    {
        _service = service;
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
    public IActionResult Post([FromBody] CreateSkillInputModel createSkill)
    {
        if (createSkill.Description.Length > 50)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new { id = createSkill.Id }, createSkill);
    }
}
