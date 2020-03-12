using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Commands.SignIn;

namespace Newsier.WebUI.Controllers
{
    public class AuthController : ApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> CheckAuthentication()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] SignInCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}