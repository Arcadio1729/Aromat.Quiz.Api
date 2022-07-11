using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Exceptions;
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

        public void AddQuestion(int setId, int questionId)
        {
            var set = this._context.QuestionSets.FirstOrDefault(q => q.Id == setId);
            var question = this._context.Questions.FirstOrDefault(q => q.Id == questionId);

            if (set is null)
            {
                throw new NotFoundException($"Set with id {setId} not found.");
            }

            if (question is null)
            {
                throw new NotFoundException($"Question with id {questionId} not found.");
            }

            QuestionSetMapping qs = new QuestionSetMapping
            {
                QuestionId = questionId,
                QuestionSetId = setId
            };

            this._context.Add(qs);
            this._context.SaveChanges();
        }

        public void CreateQuestionSet(List<Question> questions)
        {
            if(questions is null)
            {
                throw new NotFoundException($"No questions were selected.");
            }

            var tempId = this._context.QuestionSets.LastOrDefault().Id;
            var setId = tempId == 0 ? 1 : tempId;

            this._context.QuestionSets.Add(new QuestionSet
            {
                Id = setId
            });

 
            foreach(var q in questions)
            {
                this._context.QuestionSetMapping.Add(new QuestionSetMapping
                {
                    QuestionSetId = setId,
                    QuestionId = q.Id
                });
            }

            this._context.SaveChanges();
        }
    }
}
