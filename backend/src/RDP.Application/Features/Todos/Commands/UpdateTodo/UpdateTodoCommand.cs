using MediatR;

namespace RDP.Application.Features.Todos.Commands.UpdateTodo;

public record UpdateTodoCommand(Guid Id, string Title, bool IsCompleted) : IRequest<TodoDto?>;
