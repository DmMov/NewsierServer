using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using Newsier.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetCommentsByPublication
{
    public sealed class GetCommentsByPublicationQuery : IRequest<List<CommentVm>>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetCommentsByPublicationQuery, List<CommentVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<CommentVm>> Handle(GetCommentsByPublicationQuery request, CancellationToken cancellationToken)
            {
                List<CommentVm> comments = await _context.Comments
                     .Where(comment => comment.PublicationId == request.PublicationId && comment.ParentId == null)
                     .OrderByDescending(comment => comment.CreatedAt)
                     .ProjectTo<CommentVm>(_mapper.ConfigurationProvider)
                     .ToListAsync();

                comments = await StructureCommentsAsync(comments);

                return comments;
            }

            private async Task<List<CommentVm>> StructureCommentsAsync(List<CommentVm> comments)
            {
                foreach (CommentVm comment in comments)
                {
                    List<CommentVm> childComments = await _context.Comments
                        .Where(c => c.ParentId == comment.Id)
                        .OrderByDescending(comment => comment.CreatedAt)
                        .ProjectTo<CommentVm>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    if (childComments.Count != 0)
                        foreach (CommentVm innerComment in comment.Comments)
                            innerComment.Comments = await StructureCommentsAsync(childComments);
                }

                return comments;
            }
        }
    }
}
