using Aromat.Quiz.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Controllers
{
    [ApiController]
    [Route("api/ui")]
    [Authorize(Roles = "Admin,Teacher,Student")]
    public class UserController : Controller
    {
        private readonly ICourseService _courseService;

        public UserController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpGet]
        [Route("courses")]
        public ActionResult GetCourses()
        {
            var result = this._courseService.ReadCoursesByUser(User);
            return Ok(result);
        }

        [HttpGet]
        [Route("sets")]
        public ActionResult GetSets()
        {
            var result = this._courseService.ReadSets(-1);
            return Ok(result);
        }

        [HttpGet]
        [Route("courses/{courseId}")]
        public ActionResult ReadSets([FromRoute]int courseId)
        {
            var result = this._courseService.ReadSetsByUser(User,courseId);
            return Ok(result);
        }


        [HttpGet]
        [Route("courses/{courseId}/{setId}")]
        public ActionResult ReadSetContent([FromRoute]int courseId, [FromRoute]int setId)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            int sid = Convert.ToInt32(setId);

            var result = this._courseService.ReadQuestionsByUser(courseId, setId, userId);
            return Ok(result);
        }


    }
}
