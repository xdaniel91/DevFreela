using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidator()
    {
        RuleFor(e => e.Content).Length(3, 255).WithMessage("O título deve ter entre 3 e 255 caracteres.");
    }
}
