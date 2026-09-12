using MediatR;
using Microsoft.AspNetCore.Mvc;
using RDP.Application.Features.Todos;
using RDP.Application.Features.Todos.Commands.CreateTodo;
using RDP.Application.Features.Todos.Commands.DeleteTodo;
using RDP.Application.Features.Todos.Commands.UpdateTodo;
using RDP.Application.Features.Todos.Queries.GetTodoById;
using RDP.Application.Features.Todos.Queries.GetTodos;

namespace RDP.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TodoDto>>> GetAll(CancellationToken cancellationToken)
    {
        var todos = await mediator.Send(new GetTodosQuery(), cancellationToken);
        return Ok(todos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var todo = await mediator.Send(new GetTodoByIdQuery(id), cancellationToken);
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create(
        [FromBody] CreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        var todo = await mediator.Send(new CreateTodoCommand(request.Title), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TodoDto>> Update(
        Guid id,
        [FromBody] UpdateTodoRequest request,
        CancellationToken cancellationToken)
    {
        var todo = await mediator.Send(
            new UpdateTodoCommand(id, request.Title, request.IsCompleted),
            cancellationToken);

        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await mediator.Send(new DeleteTodoCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

public record CreateTodoRequest(string Title);

public record UpdateTodoRequest(string Title, bool IsCompleted);
