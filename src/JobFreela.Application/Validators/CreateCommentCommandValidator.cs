using FluentValidation;
using JobFreela.Application.Commands.CreateComment;

namespace JobFreela.Application.Validators;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        const int contentMaxLength = 255;

        RuleFor(c => c.Content)
            .MaximumLength(contentMaxLength)
            .WithMessage($"CONTENT_CHARACTER_LIMIT_EXCEEDED_MAXIMUM_OF_{contentMaxLength}");
    }
}
