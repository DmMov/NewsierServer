using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Exceptions;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.DeleteComment
{
    public sealed class DeleteCommentCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public sealed class Handler : IRequestHandler<DeleteCommentCommand, string>
        {
            private readonly INewsierContext _context;

            public Handler(INewsierContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                Comment comment = await _context.Comments
                    .SingleOrDefaultAsync(comment => comment.Id == request.CommentId);

                if (comment == null)
                    throw new NotFoundException(nameof(Comment), request.CommentId);

                _context.Comments.Remove(comment);

                await _context.SaveChangesAsync(cancellationToken);

                return comment.Id;
            }
        }
    }
}
