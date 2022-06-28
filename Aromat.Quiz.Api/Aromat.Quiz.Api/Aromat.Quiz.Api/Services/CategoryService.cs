using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly QuizDbContext _context;

        public CategoryService(QuizDbContext context)
        {
            this._context = context;
        }
        public void AddDegree(CreateDegreeDto degreeDto)
        {
            var degree = new Degree
            {
                Description = degreeDto.Description,
                SchoolDegree = degreeDto.SchoolDegree,
                School = degreeDto.School
            };

            this._context.Degrees.Add(degree);
            this._context.SaveChanges();
        }

        public void AddLevel(CreateLevelDto levelDto)
        {
            throw new NotImplementedException();
        }

        public void AddSubject(CreateSubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
