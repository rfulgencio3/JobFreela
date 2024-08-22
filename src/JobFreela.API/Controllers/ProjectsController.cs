using JobFreela.Application.Commands.CreateComment;
using JobFreela.Application.Commands.CreateProject;
using JobFreela.Application.Commands.DeleteProject;
using JobFreela.Application.Commands.FinishProject;
using JobFreela.Application.Commands.StartProject;
using JobFreela.Application.Commands.UpdateProject;
using JobFreela.Application.Queries.GetAllProjects;
using JobFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> Get(GetAllProjectsQuery query)
    {
        var projects = await _mediator.Send(query);
        
        if (projects is null) { return NotFound(); }
        
        return Ok(projects);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);
        var project = await _mediator.Send(query);

        if (project is null || Empty.Equals(project.Id)) { return NotFound(); }

        return Ok(project);
    }

    [HttpPost]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        if (!ModelState.IsValid)
        {
            var messages = ModelState
                .SelectMany(m => m.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(messages);
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "client")]
    public IActionResult Put(int id, [FromBody] UpdateProjectCommand command)
    {
        _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    [Authorize(Roles = "client")]
    [AllowAnonymous] //Remover após testes
    public async Task<IActionResult> Finish([FromBody] FinishProjectCommand finishProject)
    {
        var command = new FinishProjectCommand(finishProject.Id);
        await _mediator.Send(command);

        return NoContent();
    }
}
