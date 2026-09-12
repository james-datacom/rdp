using MediatR;
using RDP.Domain.Repositories;

namespace RDP.Application.Features.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(ITodoRepository todoRepository)
    : IRequestHandler<GetTodosQuery, IReadOnlyList<TodoDto>>
{
    public async Task<IReadOnlyList<TodoDto>> Handle(
        GetTodosQuery request,
        CancellationToken cancellationToken)
    {
        var todos = await todoRepository.GetAllAsync(cancellationToken);
        return todos.Select(TodoMapper.ToDto).ToList();
    }
}
