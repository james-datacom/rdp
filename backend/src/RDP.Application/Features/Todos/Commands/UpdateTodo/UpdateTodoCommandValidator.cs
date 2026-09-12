using FluentValidation;

namespace RDP.Application.Features.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);
    }
}
