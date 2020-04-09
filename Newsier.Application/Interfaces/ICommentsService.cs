using Newsier.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Application.Interfaces
{
    public interface ICommentsService
    {
        List<CommentVm> RestructureComments(List<CommentVm> comments);
    }
}
