using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Authentication;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(errors.FirstOrDefault().ErrorMessage);
            }

            var createdUserDto = this._service.RegisterUser(userDto);

            return Ok(createdUserDto);
        }
    
        [HttpPost]
        [Route("login")]
        public ActionResult LoginUser([FromBody]LoginDto loginDto)
        {
            var userWithToken = this._service.LoginUser(loginDto);
            return Ok(userWithToken);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult<UserWithToken>> RefreshToken([FromBody]RefreshRequest refreshRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = this._service.RefreshToken(refreshRequest);
            return Ok(result);
        }


        [HttpGet]
        [Route("roles")]
        public ActionResult GetRoles()
        {
            var roles=this._service.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("users")]
        public ActionResult GetUsers()
        {
            var users=this._service.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("users/{userId}")]
        public ActionResult GetUser([FromRoute]int userId)
        {
            var user = this._service.GetUser(userId);
            return Ok(user);
        }

        [HttpGet]
        [Route("users/course/{courseId}")]
        public ActionResult GetUsersByCourse([FromRoute] int courseId)
        {
            var users = this._service.GetUsersByCourse(courseId);
            return Ok(users);
        }

        [HttpPost]
        [Route("users/add-user")]
        public ActionResult CreateUser([FromBody]AddUserDto addUserDto)
        {
            this._service.CreateUser(addUserDto);
            return Ok(addUserDto);
        }

        [HttpPut]
        [Route("users/update-user")]
        public ActionResult UpdateResult([FromBody]UpdateUserDto updateUserDto)
        {
            this._service.UpdateUser(updateUserDto);
            return Ok(updateUserDto);
        }

        [HttpPost]
        [Route("roles/add-role/{roleName}")]
        public ActionResult AddRole([FromRoute]string roleName)
        {
            this._service.AddRole(roleName);
            return Ok();
        }

        [HttpDelete]
        [Route("users/remove")]
        public ActionResult RemoveUser([FromQuery] int userId)
        {
            this._service.RemoveUser(userId);
            return Ok();
        }
    }
}
