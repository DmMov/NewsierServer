using FluentValidation;

namespace Newsier.Application.Commands.SignUp
{
    public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("'Email' is null or an empty string")
                .EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("'Password' is null or an empty string")
                .MinimumLength(5)
                .WithMessage("'Password' length must be at least 5 characters");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Name' is null or an empty string")
                .MinimumLength(3)
                .WithMessage("'Name' length must be at least 3 characters");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("'Surname' is null or an empty string")
                .MinimumLength(3)
                .WithMessage("'Surname' length must be at least 3 characters");
        }
    }
}
