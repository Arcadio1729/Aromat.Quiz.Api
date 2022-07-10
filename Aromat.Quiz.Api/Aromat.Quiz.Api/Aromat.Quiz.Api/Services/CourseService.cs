using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void AddCourse(CourseDetailsDto courseDto)
        {
            var course = this._mapping.Map<CourseDetails>(courseDto);

            this._context.CourseDetails.Add(course);
            this._context.SaveChanges();
        }

        public void AddQuestion(QuestionSet questionSet, Question question)
        {
            throw new NotImplementedException();

        }

        public void CreateQuestionSet(List<Question> questions)
        {
            throw new NotImplementedException();
        }
    }
}
