using RDP.Domain.Entities;

namespace RDP.Domain.Repositories;

public interface ITodoRepository
{
    Task<IReadOnlyList<Todo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken = default);
    Task<Todo?> UpdateAsync(Todo todo, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
