using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services.QuestionFilterStrategy
{
    public class FullFilterStrategy : IQuestionFilterStrategy
    {
        private readonly QuizDbContext _context;

        public FullFilterStrategy(QuizDbContext context)
        {
            this._context = context;
        }
        public List<ReadQuestionDto> createFilter(
            string levelId,
            string degreeId, 
            string subjectId)
        {
            List<ReadQuestionDto> questions = this._context
               .QuestionsDetails
               .Include(q => q.Category)
               .Where(q =>
                   q.Category.LevelId == Convert.ToInt32(levelId) &&
                   q.Category.SubSubjectId == Convert.ToInt32(subjectId) &&
                   q.Category.DegreeId == Convert.ToInt32(degreeId)
               ).Include(q => q.Question)
                .Select(q =>
                    new ReadQuestionDto
                    {
                        Content = q.Question.Content,
                        Id = q.Id,
                        Image = q.Question.FileData.Data,
                        Subject = q.Category.Subject.Name,
                        Level = q.Category.Level.Name,
                        Degree = q.Category.Degree.Description
                    })
                .ToList();

            return questions;
        }
    }
}
