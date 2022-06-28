using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("add-level")]
        public ActionResult CreateLevel([FromBody]CreateLevelDto level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._service.AddLevel(level);
            return Ok();
        }
    }
}
