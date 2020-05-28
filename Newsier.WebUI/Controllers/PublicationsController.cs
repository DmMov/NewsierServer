using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.CreatePublication;
using Newsier.Application.Commands.DeletePublication;
using Newsier.Application.Queries.GetAllPublications;
using Newsier.Application.Queries.GetPopularPublications;
using Newsier.Application.Queries.GetPublicationById;
using Newsier.Application.Queries.GetPublicationsByPublisher;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public sealed class PublicationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<PublicationVm>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPublicationsQuery()));
        }

        [HttpGet("popular")]
        public async Task<ActionResult<List<PublicationVm>>> GetPupular(short? count)
        {
            return Ok(await Mediator.Send(new GetPopularPublicationsQuery { Count = count }));
        }

        [Authorize]
        [HttpGet("by-publisher")]
        public async Task<ActionResult<List<PublicationVm>>> GetByPublisher()
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await Mediator.Send(new GetPublicationsByPublisherQuery { PublisherId = publisherId }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailedPublicationVm>> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetPublicationByIdQuery { PublicationId = id }));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreatePublicationCommand command)
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            command.PublisherId = publisherId;
            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            await Mediator.Send(new DeletePublicationCommand { PublicationId = id });

            return NoContent();
        }
    }
}