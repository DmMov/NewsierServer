using MediatR;
using Newsier.Application.Exceptions;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.CreateComment
{
    public sealed class CreateCommentCommand : IRequest<string>
    {
        public string Value { get; set; }
        public string PublisherId { get; set; }
        public string PublicationId { get; set; }
        public string ParentId { get; set; }

        public sealed class Handler : IRequestHandler<CreateCommentCommand, string>
        {
            private readonly INewsierContext _context;

            public Handler(INewsierContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                Comment comment = new Comment
                {
                    Id = Guid.NewGuid().ToString(),
                    Value = request.Value,
                    PublisherId = request.PublisherId,
                    PublicationId = request.PublicationId,
                    ParentId = request.ParentId
                };
                
                _context.Comments.Add(comment);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (Exception)
                {
                    throw new BadRequestException("You provided invalid data that is why you can not create a comment");
                }

                return comment.Id;
            }
        }
    }
}