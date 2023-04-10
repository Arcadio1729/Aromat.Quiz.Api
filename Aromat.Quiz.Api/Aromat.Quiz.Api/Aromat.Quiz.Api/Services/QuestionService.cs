using Aromat.Quiz.Api.Exceptions;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            var cats = this._context.CategoryDetails;

            var questionDetails = this._context.CategoryDetails
                .Where(c =>
                    c.DegreeId == question.DegreeId && 
                    c.SubjectId == question.SubjectId &&
                    c.LevelId == question.LevelId)
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
                QuizQuestion = question.TestQuestion,
                Content = question.Content
            });
            this._context.SaveChanges();
            #endregion

        }
        public string GetAll(
            string levelId,
            string degreeId,
            string subjectId,
            string searchPhrase)
        {
            List<ReadQuestionDto> questions = this._context
               .QuestionsDetails
               .Include(q => q.Category)
               .Where(q =>
                   (levelId==null) || (q.Category.LevelId == Convert.ToInt32(levelId))
                   )
               .Where(q =>
                   (degreeId == null) || (q.Category.DegreeId == Convert.ToInt32(degreeId))
                   )
               .Where(q =>
                   (subjectId == null) || (q.Category.SubSubjectId == Convert.ToInt32(subjectId))
                   )
               .Include(q => q.Question)
               .Select(q =>
                    new ReadQuestionDto
                    {
                        Id = q.Question.Id,
                        Content = q.Question.Content,
                        Image = q.Question.FileData.Data,
                        Subject = q.Category.Subject.Name,
                        Level = q.Category.Level.Description,
                        Degree = q.Category.Degree.Description
                    })
               .Where(q=>
                    (searchPhrase == null) || (q.Content.ToLower().Trim().Contains(searchPhrase.ToLower().Trim()))
                    )
                .ToList();

            var json = JsonConvert.SerializeObject(questions);
            return json;
        }

        public string GetBySet(int setId)
        {
            List<ReadQuestionDto> questions = this._context
                .QuestionSetMapping
                .Where(q => q.QuestionSetId == setId)
                .Include(qd=>qd.Question.QuestionsDetails)
                .Include(c=>c.Question.QuestionsDetails.Category)
                .Select(q=>new ReadQuestionDto
                {
                    Content=q.Question.Content,
                    Degree=q.Question.QuestionsDetails.Category.Degree.Description,
                    Level=q.Question.QuestionsDetails.Category.Level.Description,
                    Image=q.Question.FileData.Data,
                    Subject=q.Question.QuestionsDetails.Category.Subject.Name,
                    Id=q.QuestionId
                })
                .ToList();

            var json = JsonConvert.SerializeObject(questions);
            return json;
        }
        public void RemoveQuestion(int id)
        {
            var questionToBeRemoved = this._context.Questions
                .Include(q => q.QuestionsDetails)
                .Where(q => q.Id == id)
                .FirstOrDefault();
            var questionDetails = questionToBeRemoved.QuestionsDetails;
            
            var resultQuestionDetails = this._context.QuestionsDetails.Remove(questionDetails);
            //var result = this._context.Questions.Remove(questionToBeRemoved);

            this._context.SaveChanges();
        }
        public string GetById(int questionId)
        {

            Category cat = this._context.QuestionsDetails
                .Where(q => q.QuestionId == questionId)
                .Include(q=>q.Category)
                .Select(q=>new Category
                {
                    Id=q.Category.Id,
                    DegreeId = q.Category.DegreeId,
                    LevelId = q.Category.LevelId,
                    SubSubjectId = q.Category.SubSubjectId,
                })
                .FirstOrDefault();

            ReadQuestionDetailsDto question = this._context.Questions
                .Include(q => q.QuestionsDetails)
                .Include(q => q.FileData)
                .Where(q => q.QuestionsDetails.QuestionId == questionId)    
                .Select(q=> new ReadQuestionDetailsDto
                {
                    DegreeId = q.QuestionsDetails.Category.DegreeId,
                    LevelId = q.QuestionsDetails.Category.LevelId,
                    SubjectId = q.QuestionsDetails.Category.SubSubjectId,
                    Image = q.FileData.Data,
                    ImageId = q.FileData.Id,
                    Id = q.QuestionsDetails.QuestionId
                })
                .FirstOrDefault();

            var json = JsonConvert.SerializeObject(question);
            return json;
        }

        public void UpdateQuestion(UpdateQuestionDto questionDto)
        {

            QuestionDetails questionDetails = this._context
                            .QuestionsDetails
                            .Include(qd => qd.Category)
                            .Include(qd => qd.Question)
                            .Where(q => q.QuestionId == questionDto.Id)
                            .FirstOrDefault();

            int questionId = questionDetails.Question.Id;

            FileData fileData = this._context
                            .FileData
                            .Where(f => f.Id == questionDto.QuestionImageId)
                            .FirstOrDefault();

            Category category = this._context.Categories
                    .Where(c =>
                            c.DegreeId == questionDto.DegreeId &&
                            c.SubSubjectId == questionDto.SubjectId &&
                            c.LevelId == questionDto.LevelId)
                    .FirstOrDefault();

            Question question = this._context.Questions
                    .Where(q => q.Id == questionId)
                    .Include(q => q.FileData)
                    .Include(q => q.QuestionsDetails)
                    .FirstOrDefault();

            questionDetails.Category = category;

            question.FileData = fileData;
            question.QuestionsDetails = questionDetails;


            this._context.Questions.Update(question);
            this._context.SaveChangesAsync();

        }
    }
}
