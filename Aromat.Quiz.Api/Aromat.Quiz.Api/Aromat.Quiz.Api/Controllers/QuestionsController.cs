﻿using Aromat.Quiz.Api.Model.Dto;
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
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateQuestion(
            [FromBody]CreateQuestionDto questionDto,
            [FromBody]CreateAnswerDto answerDto)
        {
            return Ok();
        }
    }


}
