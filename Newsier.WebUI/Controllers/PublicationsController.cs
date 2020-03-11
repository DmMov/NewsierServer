using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetPublications;

namespace Newsier.WebUI.Controllers
{
    public class PublicationsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<PublicationVm>>> Get()
        {
            return Ok(await Mediator.Send(new GetPublicationsQuery()));
        }
    }
}