using MediatR;
using RDP.Domain.Entities;
using RDP.Domain.Repositories;

namespace RDP.Application.Features.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<CreateTodoCommand, TodoDto>
{
    public async Task<TodoDto> Handle(
        CreateTodoCommand request,
        CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        var created = await todoRepository.AddAsync(todo, cancellationToken);
        return TodoMapper.ToDto(created);
    }
}
