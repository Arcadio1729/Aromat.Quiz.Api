using Aromat.Quiz.Api.Model;
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
    [Route("api/courses")]
    [Authorize(Roles ="Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }


        [HttpGet]
        [Route("all")]
        [Authorize]
        public ActionResult ReadCourses()
        {
            var result = this._service.ReadCourses(User);

            return Ok(result);
        }

        [HttpPost]
        [Route("add-course")]
        public ActionResult AddCourse([FromBody]CourseDetailsDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateCourse(courseDto);
            return Ok();
        }


        [HttpPost]
        [Route("add-set")]
        public ActionResult AddSet([FromBody]AddSetsToCourseDto setsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.AddSetsToCourse(setsDto);
            return Ok();
        }

        [HttpPost]
        [Route("sets/add-set")]
        public ActionResult AddSet([FromBody]List<QuestionDto> questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateSet(questions);
            return Ok();
        }

        [HttpPost]
        [Route("sets/add-questions")]
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
    
        [HttpPost]
        [Route("add-course-student")]
        public ActionResult AddCourseStudent([FromBody]CourseStudentDto courseStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.AddCourseStudent(courseStudentDto);
            return Ok();
        }
    }
}
