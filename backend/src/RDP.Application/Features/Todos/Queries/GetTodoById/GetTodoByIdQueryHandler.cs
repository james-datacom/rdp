using MediatR;
using RDP.Domain.Repositories;

namespace RDP.Application.Features.Todos.Queries.GetTodoById;

public class GetTodoByIdQueryHandler(ITodoRepository todoRepository)
    : IRequestHandler<GetTodoByIdQuery, TodoDto?>
{
    public async Task<TodoDto?> Handle(
        GetTodoByIdQuery request,
        CancellationToken cancellationToken)
    {
        var todo = await todoRepository.GetByIdAsync(request.Id, cancellationToken);
        return todo is null ? null : TodoMapper.ToDto(todo);
    }
}
