using FluentValidation;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;

namespace Newsier.Application.Commands.DeleteComment
{
    public sealed class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        private readonly IEntitiesSearchService _entitiesSearchService;

        public DeleteCommentCommandValidator(IEntitiesSearchService entitiesSearchService)
        {
            _entitiesSearchService = entitiesSearchService;

            RuleFor(x => x.CommentId)
                .NotEmpty()
                .WithMessage("'CommentId' is null or an empty string")
                .MustAsync(_entitiesSearchService.ExistAsync<Comment>)
                .WithMessage("There is no comment with the specified 'CommentId'");
        }
    }
}
