using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Email).EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(e => e.Username).NotEmpty().WithMessage("Username é obrigatório.");
    }
}
