using Newsier.Application.ViewModels;
using System.Collections.Generic;

namespace Newsier.Application.Interfaces
{
    public interface ICommentsService
    {
        List<CommentVm> RestructureComments(List<CommentVm> comments);
    }
}
