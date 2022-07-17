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
                return BadRequest();
            }

            this._service.RegisterUser(userDto);

            return Ok();
        }
    
        [HttpPost]
        [Route("login")]
        public ActionResult LoginUser([FromBody]LoginDto loginDto)
        {
            string token = this._service.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
