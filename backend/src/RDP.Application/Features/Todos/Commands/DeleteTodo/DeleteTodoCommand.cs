using MediatR;

namespace RDP.Application.Features.Todos.Commands.DeleteTodo;

public record DeleteTodoCommand(Guid Id) : IRequest<bool>;
