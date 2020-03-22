using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetPublications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public class PublicationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<PublicationVm>>> Get()
        {
            return Ok(await Mediator.Send(new GetPublicationsQuery()));
        }
    }
}