using AutoMapper;
using MediatR;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.CreateComment
{
    public sealed class CreateCommentCommand : IRequest<string>, IMapTo<Comment>
    {
        public string Value { get; set; }
        public string PublisherId { get; set; }
        public string PublicationId { get; set; }

        public sealed class Handler : HandlerBase, IRequestHandler<CreateCommentCommand, string>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                Comment comment = _mapper.Map<Comment>(request);
                comment.Id = Guid.NewGuid().ToString();

                _context.Comments.Add(comment);

                await _context.SaveChangesAsync(cancellationToken);

                return comment.Id;
            }
        }
    }
}