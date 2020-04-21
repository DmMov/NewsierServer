using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Commands.CreateComment
{
    public sealed class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public CreateCommentCommandValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("'Value' is null or an empty string")
                .MinimumLength(5)
                .WithMessage("'Value' length must be greater than 5 characters")
                .MaximumLength(256)
                .WithMessage("'Value' length must not be greater than 256 characters");

            RuleFor(x => x.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publication>)
                .WithMessage("There is no publication with the specified 'PublicationId'");

            RuleFor(x => x.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publisher>)
                .WithMessage("There is no publisher with the specified 'PublisherId'");
        }
    }
}