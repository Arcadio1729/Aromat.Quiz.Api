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
        void CreateCourse(CreateCourseDto courseDto);
        void RemoveCourse(int id);
        void RemoveSet(int setId);
        void CreateSet(CreateSetDto set);
        void AddSetsToCourse(AddSetsToCourseDto sets);
        void AddQuestionsToSet(int setId, List<QuestionDto> questions);
        void AddCourseStudent(CourseStudentDto courseStudent);
        void AddCoursesStudent(AddCoursesToUserDto addCoursesToUserDto);
        void RemoveQuestionFromSets(RemoveQuestionsFromSetDto removeQuestionsFromSetDto);
        void RemoveCourseFromUsers(RemoveCoursesFromUserDto removeCoursesFromUserDto);
        void RemoveSetsFromCourse(RemoveSetsFromCourse removeSetsFromCourseDto);
        string ReadCourses();
        string ReadCoursesByUser(int userId);
        
        string ReadCourses(ClaimsPrincipal user);

        string ReadSetContent(int setId);
        string ReadSets(int setId);
    }
}
