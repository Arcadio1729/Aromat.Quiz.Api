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
            var questionDetails = this._context.CategoryDetailsView
                .Where(c =>
                    c.Degree == question.Degree && c.Level == question.Level && c.Subsubject == question.Subject)
                .FirstOrDefault();

            this._context.Questions.Add(new Question
            {
                QuestionsDetails = new QuestionDetails
                {
                    CategoryId=questionDetails.CategoryId,
                    UniqueId=System.Guid.NewGuid().ToString(),
                },

                LatexContent = question.LatexContent,
                ImageContent = question.ImageContent,
                QuizQuestion = question.TestQuestion
            });
        }
    }
}
