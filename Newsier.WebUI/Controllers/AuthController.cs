using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.SignIn;
using Newsier.Application.Queries.GetPublisher;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public class AuthController : BaseController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> CheckAuthentication()
        {
            string publisherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await Mediator.Send(new GetPublisherQuery { PublisherId = publisherId }));
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] SignInCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}