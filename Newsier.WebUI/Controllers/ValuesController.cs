using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetAllValues;

namespace Newsier.WebUI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAll()
        {
            var query = new GetAllValuesQuery();
            return Ok(await Mediator.Send(query));
        }
    }
}