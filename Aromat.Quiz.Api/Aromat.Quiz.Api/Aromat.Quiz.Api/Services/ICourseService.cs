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
        void AddUsersStudent(AddUsersToCourseDto addUsersToCourseDto);
        void AddSetsToCourse(AddSetsToCourseDto sets);
        void AddQuestionsToSet(int setId, List<QuestionDto> questions);
        void AddCourseStudent(CourseStudentDto courseStudent);
        void AddCoursesStudent(AddCoursesToUserDto addCoursesToUserDto);
        string GetSetName(int setId);
        void RemoveQuestionFromSets(RemoveQuestionsFromSetDto removeQuestionsFromSetDto);
        void RemoveCourseFromUsers(RemoveCoursesFromUserDto removeCoursesFromUserDto);
        void RemoveSetsFromCourse(RemoveSetsFromCourse removeSetsFromCourseDto);
        string ReadCourses();
        
        string ReadCourses(ClaimsPrincipal user);

        string ReadSetContent(int setId);
        string ReadSets(int setId);

        #region user service
        string ReadCoursesByUser(ClaimsPrincipal user);
        string ReadCoursesByUser(int userId);
        string ReadSetsByUser(ClaimsPrincipal user, int userId);
        string ReadQuestionsByUser(int courseId, int setId, int userId);
        #endregion
    }
}
