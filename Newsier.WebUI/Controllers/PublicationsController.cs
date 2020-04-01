using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetAllPublications;
using Newsier.Application.Queries.GetPopularPublications;
using Newsier.Application.ViewModels;
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

        [HttpGet("popular")]
        public async Task<ActionResult<List<PublicationVm>>> GetPupular(ushort? count)
        {
            return Ok(await Mediator.Send(new GetPopularPublicationsQuery { Count = count }));
        }
    }
}