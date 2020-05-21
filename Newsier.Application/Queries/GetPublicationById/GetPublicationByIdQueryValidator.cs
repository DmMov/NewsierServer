using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Queries.GetPublicationById
{
    public sealed class GetPublicationByIdQueryValidator : AbstractValidator<GetPublicationByIdQuery>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public GetPublicationByIdQueryValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(query => query.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publication>)
                .WithMessage("The specified 'PublicationId' is invalid");
        }
    }
}
