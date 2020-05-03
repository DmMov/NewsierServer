using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Queries.GetCommentsByPublication
{
    public sealed class GetCommentsByPublicationQueryValidator : AbstractValidator<GetCommentsByPublicationQuery>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public GetCommentsByPublicationQueryValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(query => query.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publication>)
                .WithMessage("The specified 'PublicationId' is invalid");

            RuleFor(query => query.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publisher>)
                .WithMessage("The specified 'PublisherId' is invalid");
        }
    }
}
