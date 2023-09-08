using Aromat.Quiz.Api.Model.Authentication;
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
    [Authorize(Roles = "Admin,Teacher")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("add-question")]
        public ActionResult CreateQuestion([FromBody]CreateQuestionDto questionDto)
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

        #region user service
        [HttpGet]
        [Route("{courseId}/{setId}")]
        [Authorize(Roles = "Student")]
        public ActionResult GetByCourseSet([FromRoute]int courseId, [FromRoute]int setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = this._service.GetQuestionsByCourseSet(User, courseId, setId);
            return Ok(result);
        }
        #endregion

        [HttpPut]
        [Route("edit")]
        public ActionResult UpdateQuestion([FromBody]UpdateQuestionDto updateQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.UpdateQuestion2(updateQuestionDto);
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public ActionResult RemoveQuestion([FromRoute]int id)
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



