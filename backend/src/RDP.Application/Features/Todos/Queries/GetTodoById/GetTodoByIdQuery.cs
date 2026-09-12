using MediatR;

namespace RDP.Application.Features.Todos.Queries.GetTodoById;

public record GetTodoByIdQuery(Guid Id) : IRequest<TodoDto?>;
