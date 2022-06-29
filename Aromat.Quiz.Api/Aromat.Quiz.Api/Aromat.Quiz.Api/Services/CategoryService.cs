using Aromat.Quiz.Api.Exceptions;
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
            var level = new Level
            {
                Description = levelDto.Description,
                Name = levelDto.Name
            };

            this._context.Add(level);
            this._context.SaveChanges();
        }

        public void AddSubject(CreateSubjectDto subjectDto)
        {
            var baseSubject = this._context
                .Subjects
                .FirstOrDefault(s => s.Name == subjectDto.BaseSubject);

            if(baseSubject is null)
                throw new NotFoundException($"Base Subject {subjectDto.BaseSubject} does not exist.");

            this._context.SubSubjects.Add(
                new SubSubject
                {
                    SubjectId = baseSubject.Id,
                    Name = subjectDto.SubSubject
                });

            this._context.SaveChanges();
        }

        public void AddCategory()
        {
            var degrees = this._context.Degrees;
            var levels = this._context.Levels;
            var subjects = this._context.Subjects;

            var categoryProduct = from d in degrees
                                  from l in levels
                                  from s in subjects
                                  select new Category
                                  {
                                      DegreeId = d.Id,
                                      LevelId = l.Id,
                                      SubSubjectId = s.Id
                                  };

            this._context.Categories.AddRange(categoryProduct);
            this._context.SaveChanges();
        }
    }
}
