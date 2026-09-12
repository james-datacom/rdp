using MediatR;

namespace RDP.Application.Features.Todos.Queries.GetTodos;

public record GetTodosQuery : IRequest<IReadOnlyList<TodoDto>>;
