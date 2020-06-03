using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.SignIn;
using Newsier.Application.Commands.SignUp;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public sealed class AuthController : BaseController
    {
        [HttpPost("sign-in")]
        public async Task<ActionResult<string>> SignIn(SignInCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<string>> SignUp([FromForm] SignUpCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}