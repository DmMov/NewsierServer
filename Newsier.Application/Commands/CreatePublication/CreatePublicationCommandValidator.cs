using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Commands.CreatePublication
{
    public sealed class CreatePublicationCommandValidator : AbstractValidator<CreatePublicationCommand>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public CreatePublicationCommandValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("'Title' is null or an empty string")
                .MinimumLength(32)
                .WithMessage("'Title' length must be greater than 5 characters")
                .MaximumLength(256)
                .WithMessage("'Title' length must not be greater than 256 characters");

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("'Value' is null or an empty string")
                .MinimumLength(300)
                .WithMessage("'Value' length must be greater than 300 characters");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("'CategoryId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Category>)
                .WithMessage("You can't create a publication, because there is no category with the specified 'CategoryId'");

            RuleFor(x => x.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publisher>)
                .WithMessage("You can't create a publication, because there is no publisher with the specified 'PublisherId'");
        }
    }
}
