using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface ICourseService
    {
        void AddCourse(CourseDetailsDto courseDto);
        void CreateQuestionSet(List<Question> questions);
        void AddQuestion(QuestionSet questionSet, Question question);
    }
}
