using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetCommentById
{
    public sealed class GetCommentByIdQuery : IRequest<CommentSimpleVm>
    {
        public string CommentId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetCommentByIdQuery, CommentSimpleVm>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<CommentSimpleVm> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                CommentSimpleVm comment = await _context.Comments
                    .ProjectTo<CommentSimpleVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(comment => comment.Id == request.CommentId);

                return comment;
            }
        }
    }
}
