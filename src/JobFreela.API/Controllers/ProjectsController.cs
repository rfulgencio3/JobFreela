using JobFreela.Application.Commands.CreateComment;
using JobFreela.Application.Commands.CreateProject;
using JobFreela.Application.Commands.DeleteProject;
using JobFreela.Application.Commands.FinishProject;
using JobFreela.Application.Commands.StartProject;
using JobFreela.Application.Commands.UpdateProject;
using JobFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);
        var project = await _mediator.Send(query);

        if (project is null || Empty.Equals(project.Id)) { return NotFound(); }

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        if (command.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectCommand command)
    {
        if (command.Description.Length > 200)
        {
            return BadRequest();
        }

        _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public async Task<IActionResult> Finish(int id)
    {
        var command = new FinishProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }
}
