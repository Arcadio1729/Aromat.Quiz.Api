using Aromat.Quiz.Api.Exceptions;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapping;
        public CategoryService(QuizDbContext context, IMapper mapping)
        {
            this._context = context;
            this._mapping = mapping;
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
            var subjects = this._context.SubSubjects;

            var categoryProduct = from d in degrees
                                  from l in levels
                                  from s in subjects
                                  select new Category
                                  {
                                      DegreeId = d.Id,
                                      LevelId = l.Id,
                                      SubSubjectId = s.Id
                                  };

            categoryProduct = categoryProduct.Where(cp =>
                cp.SubSubjectId != 1 &&
                cp.SubSubjectId != 2 &&
                cp.SubSubjectId != 3 &&
                cp.SubSubjectId != 4 &&
                cp.SubSubjectId != 5);

            this._context.Categories.AddRange(categoryProduct);
            this._context.SaveChanges();
        }


        public string ReadDegrees()
        {
            List<Degree> degrees = this._context.Degrees.ToList();
            var degreesDto = this._mapping.Map<List<ReadDegreeDto>>(degrees);

            var json = JsonConvert.SerializeObject(degreesDto);
            return json;
        }
        public string ReadLevels()
        {
            List<Level> levels = this._context.Levels.ToList();
            var levelsDto = this._mapping.Map<List<ReadLevelDto>>(levels);

            var json = JsonConvert.SerializeObject(levelsDto);
            return json;
        }
        public string ReadSubjects()
        {
            List<SubSubjectDto> subjects = this._context
                .SubSubjects
                .Include(s=>s.Subject)
                .ToList()
                .Select(s => new SubSubjectDto
                {
                    Id = s.Id,
                    BaseSubject = s.Subject.Name,
                    Subject = s.Name
                })
                .ToList();

            //var subjectsDto = this._mapping.Map<List<ReadSubjectDto>>(subjects);

            var json = JsonConvert.SerializeObject(subjects);
            return json;
        }
        public string ReadBaseSubjects()
        {
            List<ReadSubjectDto> subjects = this._context
                .Subjects
                .Select(s=>new ReadSubjectDto
                {
                    Id=s.Id,
                    Name=s.Name
                })
                .ToList();

            var json = JsonConvert.SerializeObject(subjects);
            return json;
        }

    }
}
