using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Controllers
{
    [ApiController]
    [Route("api/questions")]
    [Authorize(Roles = "Student")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            this._service = service;
        }

        [Route("add-question")]
        public ActionResult CreateQuestion([FromBody] CreateQuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateQuestion(questionDto);
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll(
            [FromQuery]string levelId,
            [FromQuery]string degreeId,
            [FromQuery]string subjectId,
            [FromQuery]string searchPhrase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = this._service.GetAll(levelId,degreeId,subjectId, searchPhrase);
            return Ok(result);
        }

        [HttpGet]
        [Route("{questionId}")]
        public ActionResult GetById([FromRoute]int questionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = this._service.GetById(questionId);
            return Ok(result);
        }

        [HttpGet]
        [Route("set/{setId}")]
        public ActionResult GetBySet([FromRoute]string setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = this._service.GetBySet(Convert.ToInt32(setId));
            return Ok(result);
        }

        [HttpPut]
        [Route("edit")]
        public ActionResult UpdateQuestion([FromBody]UpdateQuestionDto updateQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.UpdateQuestion(updateQuestionDto);
            return Ok();
        }

        [HttpDelete]
        [Route("remove")]
        public ActionResult RemoveQuestion([FromQuery]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveQuestion(id);
            return Ok();
        }
    }
}



