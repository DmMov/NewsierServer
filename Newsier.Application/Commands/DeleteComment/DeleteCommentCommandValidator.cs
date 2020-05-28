using FluentValidation;

namespace Newsier.Application.Commands.DeleteComment
{
    public sealed class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty()
                .WithMessage("'CommentId' is null or an empty string");
        }
    }
}
