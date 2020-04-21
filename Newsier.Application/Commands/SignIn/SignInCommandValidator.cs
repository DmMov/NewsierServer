
using FluentValidation;
using Newsier.Application.Interfaces;

namespace Newsier.Application.Commands.SignIn
{
    public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator(IEntitiesSearchService entitiesSearchService)
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
                .WithMessage("'Password' length must be greater than 5 characters");
        }
    }
}
