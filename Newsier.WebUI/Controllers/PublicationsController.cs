using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetAllPublications;
using System.Collections.Generic;
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
    }
}