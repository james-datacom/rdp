using System.Collections.Concurrent;
using RDP.Domain.Entities;
using RDP.Domain.Repositories;

namespace RDP.Infrastructure.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly ConcurrentDictionary<Guid, Todo> _todos = new();

    public Task<IReadOnlyList<Todo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var todos = _todos.Values
            .OrderByDescending(t => t.CreatedAt)
            .ToList();

        return Task.FromResult<IReadOnlyList<Todo>>(todos);
    }

    public Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _todos.TryGetValue(id, out var todo);
        return Task.FromResult(todo);
    }

    public Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken = default)
    {
        _todos[todo.Id] = todo;
        return Task.FromResult(todo);
    }

    public Task<Todo?> UpdateAsync(Todo todo, CancellationToken cancellationToken = default)
    {
        if (!_todos.ContainsKey(todo.Id))
        {
            return Task.FromResult<Todo?>(null);
        }

        _todos[todo.Id] = todo;
        return Task.FromResult<Todo?>(todo);
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_todos.TryRemove(id, out _));
    }
}
