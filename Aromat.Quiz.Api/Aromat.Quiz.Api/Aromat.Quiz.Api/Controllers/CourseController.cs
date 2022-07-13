using Aromat.Quiz.Api.Model;
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
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("add-course")]
        public ActionResult AddCourse([FromBody]CourseDetailsDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.AddCourse(courseDto);
            return Ok();
        }

        [HttpPost]
        [Route("create-set")]
        public ActionResult CreateSet([FromBody]List<QuestionDto> questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateQuestionSet(questions);
            return Ok();
        }

        [HttpPost]
        [Route("add-question-set")]
        public ActionResult AddQuestionsToSet([FromBody] AddQuestionsToSetDto questionsSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var setId = questionsSet.SetId;
            this._service.AddQuestionsToSet(setId, questionsSet.Questions);
            return Ok();
        }
    }
}
