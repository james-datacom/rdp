namespace RDP.Application.Features.Todos;

public record TodoDto(Guid Id, string Title, bool IsCompleted, DateTime CreatedAt);
