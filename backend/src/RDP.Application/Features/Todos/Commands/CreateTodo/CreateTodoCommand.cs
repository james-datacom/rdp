using MediatR;

namespace RDP.Application.Features.Todos.Commands.CreateTodo;

public record CreateTodoCommand(string Title) : IRequest<TodoDto>;
