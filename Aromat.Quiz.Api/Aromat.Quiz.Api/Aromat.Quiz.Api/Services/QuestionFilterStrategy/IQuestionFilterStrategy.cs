using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services.QuestionFilterStrategy
{
    public interface IQuestionFilterStrategy
    {
        List<ReadQuestionDto> createFilter(
            string levelId,
            string degreeId,
            string subjectId);
    }
}
