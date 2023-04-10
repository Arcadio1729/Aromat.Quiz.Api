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
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult ReadCourses()
        {
            var result = this._service.ReadCourses();

            return Ok(result);
        }

        [HttpGet]
        [Route("users/{userId}")]
        public ActionResult ReadCourses([FromRoute]int userId)
        {
            var result = this._service.ReadCoursesByUser(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("sets")]
        public ActionResult ReadSets([FromQuery]string courseId)
        {
            int cid = Convert.ToInt32(courseId);
            var result = this._service.ReadSets(cid);

            return Ok(result);
        }


        [HttpGet]
        [Route("set")]
        public ActionResult ReadSet([FromQuery]string setId)
        {
            int sid = Convert.ToInt32(setId);
            var result = this._service.ReadSetContent(sid);

            return Ok(result);
        }

        [HttpPost]
        [Route("add-course")]
        public ActionResult AddCourse([FromBody]CreateCourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateCourse(courseDto);
            return Ok();
        }

        [HttpDelete]
        [Route("remove-course/{id}")]
        public ActionResult RemoveCourse([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveCourse(id);
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
        public ActionResult AddSet([FromBody]CreateSetDto set)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.CreateSet(set);
            return Ok();
        }

        [HttpDelete]
        [Route("sets/remove-set")]
        public ActionResult RemoveSet([FromQuery]int setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveSet(setId);
            return Ok();
        }

        [HttpPost]
        [Route("sets/remove-questions")]
        public ActionResult RemoveQuestionsFromSet([FromBody]RemoveQuestionsFromSetDto removeQuestionsFromSetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveQuestionFromSets(removeQuestionsFromSetDto);
            return Ok();
        }

        [HttpPost]
        [Route("sets/add-questions")]
        public ActionResult AddQuestionsToSet([FromBody]AddQuestionsToSetDto questionsSet)
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

        [HttpPost]
        [Route("add-courses-student")]
        public ActionResult AddCoursesStudent([FromBody]AddCoursesToUserDto addCoursesToUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.AddCoursesStudent(addCoursesToUserDto);
            return Ok();
        }

        [HttpPost]
        [Route("remove-courses-student")]
        public ActionResult RemoveCoursesStudent([FromBody]RemoveCoursesFromUserDto removeCoursesFromUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveCourseFromUsers(removeCoursesFromUserDto);
            return Ok();
        }

        [HttpPost]
        [Route("remove-sets-course")]
        public ActionResult RemoveSetCourse([FromBody]RemoveSetsFromCourse removeSetsFromCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.RemoveSetsFromCourse(removeSetsFromCourse);
            return Ok();
        }
    }
}
