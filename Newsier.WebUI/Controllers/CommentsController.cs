using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.CreateComment;
using Newsier.Application.Queries.GetCommentById;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentSimpleVm>> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetCommentByIdQuery { CommentId = id }));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCommentCommand command)
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            command.PublisherId = publisherId;
            return Ok(await Mediator.Send(command));
        }
    }
}