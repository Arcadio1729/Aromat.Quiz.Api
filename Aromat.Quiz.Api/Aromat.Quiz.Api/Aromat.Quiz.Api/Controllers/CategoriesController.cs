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
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            this._service = service;
        }


        [HttpGet]
        [Route("degrees")]
        public ActionResult ReadDegrees()
        {
            var result = this._service.ReadDegrees();

            return Ok(result);
        }

        [HttpGet]
        [Route("levels")]
        public ActionResult ReadLevels()
        {
            var result = this._service.ReadLevels();

            return Ok(result);
        }


        [HttpGet]
        [Route("subjects")]
        public ActionResult ReadSubjects()
        {
            var result = this._service.ReadSubjects();
            return Ok(result);
        }

        [HttpGet]
        [Route("base-subjects")]
        public ActionResult ReadBaseSubjects()
        {
            var result = this._service.ReadBaseSubjects();
            return Ok(result);
        }
         

        [HttpPost]
        [Route("add-categories")]
        public ActionResult CreateCategories()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._service.AddCategory();
            return Ok();
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

        [HttpPost]
        [Route("add-degree")]
        public ActionResult CreateDegree([FromBody]CreateDegreeDto degree)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._service.AddDegree(degree);
            return Ok();
        }

        [HttpPost]
        [Route("subjects/add-subject")]  
        public ActionResult CreateSubject([FromBody]CreateSubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._service.AddSubject(subject);
            return Ok();
        }

        [HttpGet]
        [Route("test")]
        public ActionResult TestApi()
        {
            return Ok("Working!");
        }
    }
}
