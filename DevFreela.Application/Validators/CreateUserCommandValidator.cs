using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(e => e.Email).EmailAddress().WithMessage("Invalid email address.");
        
        RuleFor(e => e.FirstName).NotEmpty().WithMessage("Fisrt name is required.");
        
        RuleFor(e => e.Role).NotEmpty().WithMessage("Role is required.");
       
        RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required.");
        
        RuleFor(e => e.Password).NotEmpty().WithMessage("Password is required.");
       
        RuleFor(e => e.BirthDate).NotEmpty().WithMessage("Last name is required.")
            .GreaterThan(DateTime.Today.AddYears(-18)).WithMessage("User have must be older than 18 years old.");
    }
}
