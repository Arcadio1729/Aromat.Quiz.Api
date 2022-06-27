using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public interface ICategoryService
    {
        void AddSubject(CreateSubjectDto subjectDto);
        void AddLevel(CreateLevelDto levelDto);
        void AddDegree(CreateDegreeDto degreeDto);
    }
}
