using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Aromat.Quiz.Api.Controllers
{
    [ApiController]
    [Route("api/management")]
    [Authorize(Roles = "Admin")]
    public class ManagementController : Controller
    {
        private readonly IManagementService _service;
        public ManagementController(IManagementService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("add-students")]
        public ActionResult AddTeacherStudent([FromBody]List<TeacherStudentDto> teacherStudentsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this._service.AddStudentToTeacher(teacherStudentsDto);
            return Ok();
        }
    }
}
