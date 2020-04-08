using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetCommentsByPublication;
using Newsier.Application.ViewModels;

namespace Newsier.WebUI.Controllers
{
    public sealed class CommentsController : BaseController
    {
        [HttpGet("by-publication/{publicationId}")]
        public async Task<ActionResult<List<CommentVm>>> GetByPublication(string publicationId)
        {
            return Ok(await Mediator.Send(new GetCommentsByPublicationQuery { PublicationId = publicationId }));
        }
    }
}