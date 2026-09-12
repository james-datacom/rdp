using MediatR;
using RDP.Domain.Repositories;

namespace RDP.Application.Features.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<DeleteTodoCommand, bool>
{
    public async Task<bool> Handle(
        DeleteTodoCommand request,
        CancellationToken cancellationToken) =>
        await todoRepository.DeleteAsync(request.Id, cancellationToken);
}
