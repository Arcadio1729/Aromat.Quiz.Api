using Aromat.Quiz.Api.Exceptions;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuizDbContext _context;

        public QuestionService(QuizDbContext context)
        {
            this._context = context;
        }

        
        public void CreateQuestion(CreateQuestionDto question)
        {
            #region createQuestion
            var questionDetails = this._context.CategoryDetails
                .Where(c =>
                    c.Degree == question.Degree && 
                    c.School == question.School &&
                    c.Level == question.Level && 
                    c.Subject == question.Subject)
                .FirstOrDefault();

            if (questionDetails is null)
                throw new NotFoundException($"Category not found.");

            this._context.Questions.Add(new Question
            {
                QuestionsDetails = new QuestionDetails
                {
                    CategoryId = questionDetails.CategoryId,
                    UniqueId = System.Guid.NewGuid().ToString(),
                },

                LatexContent = question.LatexContent,
                FileDataId = question.QuestionImageId,
                QuizQuestion = question.TestQuestion
            });
            this._context.SaveChanges();
            #endregion

        }
    }
}
