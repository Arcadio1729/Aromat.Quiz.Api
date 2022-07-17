using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Aromat.Quiz.Api.Services
{
    public interface ICourseService
    {
        void CreateCourse(CourseDetailsDto courseDto);
        void CreateSet(List<QuestionDto> questions);
        void AddSetsToCourse(AddSetsToCourseDto sets);
        void AddQuestionsToSet(int setId, List<QuestionDto> questions);
        void AddCourseStudent(CourseStudentDto courseStudent);
        string ReadCourses(ClaimsPrincipal user);
    }
}
