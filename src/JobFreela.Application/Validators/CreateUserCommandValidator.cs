using FluentValidation;
using JobFreela.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace JobFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("INVALID_EMAIL");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("PASSWORD_MUST_CONTAIN_AT_LEAST_EIGHT_CHARACTERS_INCLUDING_A_NUMBER_AND_ONE_LOWERCASE_AND_UPPERCASE_LETTER");

        RuleFor(p => p.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("NAME_IS_REQUIRED");
    }

    public bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
