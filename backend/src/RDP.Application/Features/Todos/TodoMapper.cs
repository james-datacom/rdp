using RDP.Domain.Entities;

namespace RDP.Application.Features.Todos;

internal static class TodoMapper
{
    public static TodoDto ToDto(Todo todo) =>
        new(todo.Id, todo.Title, todo.IsCompleted, todo.CreatedAt);
}
