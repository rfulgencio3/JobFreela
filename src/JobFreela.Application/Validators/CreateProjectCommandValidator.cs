using FluentValidation;
using JobFreela.Application.Commands.CreateProject;

namespace JobFreela.Application.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        const int titleMaxLength = 50;
        const int descriptionMaxLength = 255;

        RuleFor(p => p.Title)
            .MaximumLength(titleMaxLength)
            .WithMessage($"TITLE_CHARACTER_LIMIT_EXCEEDED_MAXIMUM_OF_{titleMaxLength}");

        RuleFor(p => p.Description)
            .MaximumLength(descriptionMaxLength)
            .WithMessage($"TITLE_CHARACTER_LIMIT_EXCEEDED_MAXIMUM_OF_{descriptionMaxLength}");
    }
}
