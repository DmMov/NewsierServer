using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Queries.GetPublisherById
{
    public sealed class GetPublisherByIdQueryValidator : AbstractValidator<GetPublisherByIdQuery>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public GetPublisherByIdQueryValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(query => query.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Publisher>)
                .WithMessage("There is no publisher with the specified 'PublisherId'");
        }
    }
}
