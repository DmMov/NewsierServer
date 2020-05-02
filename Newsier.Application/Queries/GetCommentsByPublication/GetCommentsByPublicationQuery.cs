using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetCommentsByPublication
{
    public sealed class GetCommentsByPublicationQuery : IRequest<ICollection<CommentVm>>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetCommentsByPublicationQuery, ICollection<CommentVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<ICollection<CommentVm>> Handle(GetCommentsByPublicationQuery request, CancellationToken cancellationToken)
            {
                ICollection<CommentVm> comments = await _context.Comments
                     .Where(comment => comment.PublicationId == request.PublicationId)
                     .OrderByDescending(comment => comment.CreatedAt)
                     .ProjectTo<CommentVm>(_mapper.ConfigurationProvider)
                     .ToListAsync();

                return comments;
            }
        }
    }
}
