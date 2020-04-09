using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetCommentsByPublication
{
    public sealed class GetCommentsByPublicationQuery : IRequest<List<CommentVm>>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetCommentsByPublicationQuery, List<CommentVm>>
        {
            private readonly ICommentsService _commentsService;

            public Handler(INewsierContext context, IMapper mapper, ICommentsService commentsService) : base(context, mapper)
            {
                _commentsService = commentsService;
            }

            public async Task<List<CommentVm>> Handle(GetCommentsByPublicationQuery request, CancellationToken cancellationToken)
            {
                List<CommentVm> comments = await _context.Comments
                    .Include(x => x.Comments)
                    .Where(comment => comment.PublicationId == request.PublicationId)
                    .OrderByDescending(comment => comment.CreatedAt)
                    .ProjectTo<CommentVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                comments = _commentsService.RestructureComments(comments).Where(x => x.ParentId == null).ToList();

                return comments;
            }
        }
    }
}
