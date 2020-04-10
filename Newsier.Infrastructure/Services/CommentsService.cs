using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Newsier.Infrastructure.Services
{
    public sealed class CommentsService : ICommentsService
    {
        public List<CommentVm> RestructureComments(List<CommentVm> comments)
        {
            foreach (CommentVm rootComment in comments)
            {
                foreach (CommentVm innerComment in rootComment.Comments)
                {
                    if (comments.Any(x => x.ParentId == innerComment.Id))
                    {
                        innerComment.Comments = RestructureComments(comments.Where(x => x.ParentId == innerComment.Id).ToList());
                    }
                }
            }

            return comments;
        }
    }
}
