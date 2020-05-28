using Microsoft.AspNetCore.Mvc;
using Newsier.Application.Queries.GetAllCategories;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsier.WebUI.Controllers
{
    public sealed class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<CategoryVm>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
        }
    }
}