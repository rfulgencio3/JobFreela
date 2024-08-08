using JobFreela.Application.InputModels;
using JobFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;
    public ProjectsController(IProjectService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _service.GetById(id);
        if (project is null || Empty.Equals(project.Id)) { return NotFound(); }

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectInputModel inputModel)
    {
        if (inputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = _service.Create(inputModel);
        return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
    {
        if (inputModel.Description.Length > 200)
        {
            return BadRequest();
        }

        _service.Update(inputModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
    {
        _service.CreateComment(inputModel);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _service.Start(id);
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _service.Finish(id);
        return NoContent();
    }
}
