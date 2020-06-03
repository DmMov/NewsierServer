using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetPublisherById;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public sealed class PublishersController : BaseController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAuthenticatedById()
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await Mediator.Send(new GetPublisherByIdQuery { PublisherId = publisherId }));
        }
    }
}
