using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.CreateComment;
using Newsier.Application.Commands.DeleteComment;
using Newsier.Application.Queries.GetCommentsByPublication;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    [Authorize]
    public sealed class CommentsController : BaseController
    {
        [HttpGet("by-publication/{publicationId}")]
        public async Task<ActionResult<List<CommentVm>>> GetByPublication(string publicationId)
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await Mediator.Send(
                new GetCommentsByPublicationQuery
                {
                    PublicationId = publicationId,
                    PublisherId = publisherId
                }
            ));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCommentCommand command)
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            command.PublisherId = publisherId;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            await Mediator.Send(new DeleteCommentCommand { CommentId = id });

            return NoContent();
        }
    }
}