using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Aromat.Quiz.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapping;

        public CourseService(QuizDbContext context, IMapper mapping)
        {
            this._context = context;
            this._mapping = mapping;
        }


        public void CreateCourse(CourseDetailsDto courseDto)
        {
            var course = this._mapping.Map<CourseDetails>(courseDto);

            this._context.CourseDetails.Add(course);
            this._context.SaveChanges();
        }
        public void AddQuestionsToSet(int setId, List<QuestionDto> questions)
        {
            foreach (var q in questions)
            {
                this._context.QuestionSetMapping.Add(
                    new QuestionSetMapping
                    {
                        QuestionId = q.QuestionId,
                        QuestionSetId = setId
                    });
            }
            this._context.SaveChanges();
        }
        public void CreateSet(List<QuestionDto> questions)
        {
            var setId = this.CreateSet("new set");
            var currentSet = this._context.QuestionSets.FirstOrDefault(q => q.Id == setId);

            foreach(var q in questions)
            {
                this._context.QuestionSetMapping.Add(
                    new QuestionSetMapping
                        {
                            QuestionId = q.QuestionId,
                            QuestionSetId = setId
                        });
            }

            this._context.SaveChanges();
        }
        private int CreateSet(string name)
        {
            QuestionSet qs = new QuestionSet
            {
                Name = name
            };

            this._context.QuestionSets.Add(qs);
            this._context.SaveChanges();

            return qs.Id;
        }

        public string ReadCourses(ClaimsPrincipal user)
        {
            var json = user.Claims.FirstOrDefault(x => x.Type == "Courses").Value;
            //var courses = JsonConvert.DeserializeObject<List<CoursesStudents>>(json);

            return json;
        }
        public void AddSetsToCourse(AddSetsToCourseDto sets)
        {
            var courseId = sets.CourseId;

            foreach (var s in sets.Sets)
            {
                this._context.CoursesQuestionsSets.Add(
                    new CoursesQuestionsSet
                    {
                        CourseDetailsId = courseId,
                        QuestionSetId = s.SetId
                    });
            }

            this._context.SaveChanges();
        }
        public void AddCourseStudent(CourseStudentDto courseStudent)
        {
            CoursesStudents cs = new CoursesStudents
            {
                CourseDetailsId = courseStudent.CourseId,
                StudentsId = courseStudent.StudentId
            };

            this._context.CoursesStudents.Add(cs);
            this._context.SaveChanges();


        }
    }
}
