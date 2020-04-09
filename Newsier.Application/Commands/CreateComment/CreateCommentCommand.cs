using MediatR;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.CreateComment
{
    public sealed class CreateCommentCommand : IRequest<string>
    {
        public string Comment { get; set; }
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
                    Value = request.Comment,
                    PublisherId = request.PublisherId,
                    PublicationId = request.PublicationId,
                    ParentId = request.ParentId
                };
                
                await _context.Comments.AddAsync(comment);

                await _context.SaveChangesAsync(cancellationToken);

                return comment.Id;
            }
        }
    }
}
