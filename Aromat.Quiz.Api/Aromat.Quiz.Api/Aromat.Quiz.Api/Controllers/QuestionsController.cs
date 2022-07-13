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
    [Route("api/question")]
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



    }
}



