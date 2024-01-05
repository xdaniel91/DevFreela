using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(e => e.Description).Length(1, 90).WithMessage("Descrição deve ter entre 1 e 90 caracteres.");
        RuleFor(e => e.Title).Length(1, 90).WithMessage("Título deve ter entre 1 e 90 caracteres.");
        RuleFor(e => e.TotalCost).GreaterThan(0).WithMessage("Custo total deve ser maior que zero.");
    }
}
