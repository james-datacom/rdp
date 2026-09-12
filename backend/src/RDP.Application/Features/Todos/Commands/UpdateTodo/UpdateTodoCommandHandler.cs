using MediatR;
using RDP.Domain.Entities;
using RDP.Domain.Repositories;

namespace RDP.Application.Features.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<UpdateTodoCommand, TodoDto?>
{
    public async Task<TodoDto?> Handle(
        UpdateTodoCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await todoRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var updated = await todoRepository.UpdateAsync(
            new Todo
            {
                Id = request.Id,
                Title = request.Title.Trim(),
                IsCompleted = request.IsCompleted,
                CreatedAt = existing.CreatedAt
            },
            cancellationToken);

        return updated is null ? null : TodoMapper.ToDto(updated);
    }
}
