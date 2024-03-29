﻿using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface IQuestionService
    {
        void CreateQuestion(CreateQuestionDto question);
        void UpdateQuestion(UpdateQuestionDto question);
        void UpdateQuestion2(UpdateQuestionDto question);
        string GetAll(string levelId, string degreeId, string subjectId,string searchPhrase);
        string GetById(int questionId);
        string GetBySet(int setId);
        void RemoveQuestion(int id);

        #region user service
        string GetQuestionsByCourseSet(ClaimsPrincipal user, int courseId, int setId);
        #endregion
    }
}
