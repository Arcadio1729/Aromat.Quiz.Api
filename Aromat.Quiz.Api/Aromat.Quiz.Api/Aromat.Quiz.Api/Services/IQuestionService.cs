using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface IQuestionService
    {
        void CreateQuestion(CreateQuestionDto question);
    }
}
