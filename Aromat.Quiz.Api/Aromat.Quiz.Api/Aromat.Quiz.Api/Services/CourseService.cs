using Aromat.Quiz.Api.Exceptions;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Model.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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


        public void CreateCourse(CreateCourseDto courseDto)
        {
            this._context.CourseDetails.Add(new CourseDetails { Name = courseDto.Name });
            this._context.SaveChanges();
        }
        public void AddQuestionsToSet(int setId, List<QuestionDto> questions)
        {
            foreach (var q in questions)
            {
                this._context.QuestionSetMapping.Add(
                    new QuestionSetMapping
                    {
                        QuestionId = q.QuestionId,
                        QuestionSetId = setId
                    });
            }
            this._context.SaveChanges();
        }
        public void CreateSet(CreateSetDto set)
        {
            var setObj = this.CreateSet(set.Name);
            var currentSet = this._context
                                    .QuestionSets
                                    .FirstOrDefault(q => q.Id == setObj.Id);

            if (set.Questions != null)
            {
                foreach (var q in set.Questions)
                {
                    var questionObj = this._context.Questions.FirstOrDefault(x => x.Id == q.QuestionId);

                    this._context
                        .QuestionSetMapping
                        .Add(
                            new QuestionSetMapping
                            {
                                QuestionSetId = setObj.Id,
                                QuestionId = questionObj.Id,
                                QuestionSet = setObj,
                                Question = questionObj
                            }
                        );
                }
            }

            this._context.SaveChanges();
        }
        private QuestionSet CreateSet(string name)
        {
            QuestionSet qs = new QuestionSet
            {
                Name = name
            };

            this._context.QuestionSets.Add(qs);
            this._context.SaveChanges();

            return qs;
        }

        public string ReadCourses()
        {
            List<CourseDetails> courses = this._context.CourseDetails.ToList();
            var coursesDto = this._mapping.Map<List<CourseDetailsDto>>(courses);

            var json = JsonConvert.SerializeObject(coursesDto);
            return json;
        }
        public string ReadCoursesByUser(int userId)
        {
            var studentId = this._context.Students.FirstOrDefault(s => s.UserId == userId).Id;

            List<CourseDetails> coursesStudent = this._context
                                    .CoursesStudents
                                    .Where(cs => cs.StudentsId == studentId)
                                    .Select(cs => cs.CourseDetails)
                                    .ToList();

            List<DisplayItemDto> coursesDto = coursesStudent
                                            .Select(cs => new DisplayItemDto
                                            {
                                                Id = cs.Id,
                                                Content = cs.Name
                                            })
                                            .ToList();

            var json = JsonConvert.SerializeObject(coursesDto);
            return json;
        }
        public string ReadCourses(ClaimsPrincipal user)
        {
            var json = user.Claims.FirstOrDefault(x => x.Type == "Courses").Value;
            //var courses = JsonConvert.DeserializeObject<List<CoursesStudents>>(json);

            return json;
        }

        public string ReadSets(int courseId = -1)
        {
            var sets = new List<ReadSetDto>();

            if (courseId == -1)
            {
                sets = this._context.QuestionSets
                    .Select(qs => new ReadSetDto
                    {
                        Id = qs.Id,
                        Name = qs.Name
                    })
                    .ToList();
            }
            else
            {
                sets = this._context.CoursesQuestionsSets
                    .Where(cqs => cqs.CourseDetailsId == courseId)
                    .Include(cqs => cqs.QuestionSet)
                    .Select(cqs => new ReadSetDto
                    {
                        Id = cqs.QuestionSet.Id,
                        Name = cqs.QuestionSet.Name
                    })
                    .ToList();
            }

            var json = JsonConvert.SerializeObject(sets);
            return json;
        }
        public string ReadSetContent(int setId)
        {
            var set = new ReadSetContentDto();
            var questions = new List<ReadQuestionDto>();

            questions = this._context
                    .QuestionSetMapping
                    .Where(qsm => qsm.QuestionSetId == setId)
                    .Include(qsm => qsm.Question)
                    .Include(qsm => qsm.Question.QuestionsDetails)
                    .Include(qsm => qsm.Question.QuestionsDetails.Category)
                    .Select(qsm => new ReadQuestionDto
                    {
                        Subject = qsm.Question.QuestionsDetails.Category.Subject.Name,
                        Degree = qsm.Question.QuestionsDetails.Category.Degree.Description,
                        Level = qsm.Question.QuestionsDetails.Category.Level.Description,
                        Content = qsm.Question.QuestionsDetails.Question.Content,
                        Id = qsm.Question.QuestionsDetails.QuestionId
                    })
                    .ToList();

            set = new ReadSetContentDto()
            {
                Id = setId,
                Content = this._context.QuestionSets.FirstOrDefault(qs => qs.Id == setId).Name,
                Items = questions
            };

            var json = JsonConvert.SerializeObject(set);
            return json;
        }

        public void AddSetsToCourse(AddSetsToCourseDto sets)
        {
            var courseId = sets.CourseId;

            foreach (var s in sets.Sets)
            {
                this._context.CoursesQuestionsSets.Add(
                    new CoursesQuestionsSet
                    {
                        CourseDetailsId = courseId,
                        QuestionSetId = s.SetId
                    });
            }

            this._context.SaveChanges();
        }
        public void AddCourseStudent(CourseStudentDto courseStudent)
        {
            CoursesStudents cs = new CoursesStudents
            {
                CourseDetailsId = courseStudent.CourseId,
                StudentsId = courseStudent.StudentId
            };

            this._context.CoursesStudents.Add(cs);
            this._context.SaveChanges();
        }

        public void AddCoursesStudent(AddCoursesToUserDto addCoursesToUserDto)
        {
            List<CoursesStudents> coursesStudents = new List<CoursesStudents>();
            var userId = addCoursesToUserDto.UserId;
            var studentId = this._context.Students.FirstOrDefault(x => x.UserId == userId).Id;

            coursesStudents = addCoursesToUserDto.Courses
                    .Select(x =>
                        new CoursesStudents
                        {
                            CourseDetailsId = x.CourseId,
                            StudentsId = studentId
                        })
                    .ToList();

            this._context.CoursesStudents.AddRange(coursesStudents);
            this._context.SaveChanges();
        }

        public void RemoveCourse(int id)
        {
            var course = this._context.CourseDetails.FirstOrDefault(c => c.Id == id);

            if (course is null)
                throw new NotFoundException($"Course with id {id} not found.");

            this._context.CourseDetails.Remove(course);
            this._context.SaveChanges();
        }
        public void RemoveSet(int setId)
        {
            var isEmpty = (this._context.QuestionSetMapping.Count(qs => qs.QuestionSetId == setId) == 0);
            QuestionSet set = new QuestionSet();

            if (isEmpty)
            {
                set = this._context.QuestionSets.FirstOrDefault(s => s.Id == setId);
                this._context.QuestionSets.Remove(set);
                this._context.SaveChanges();
            }
            else
            {
                List<QuestionSetMapping> questions = this._context
                    .QuestionSetMapping
                    .Where(qsm => qsm.QuestionSetId == setId)
                    .ToList();

                this._context.QuestionSetMapping.RemoveRange(questions);
                this._context.SaveChanges();

                set = this._context.QuestionSets.FirstOrDefault(s => s.Id == setId);

                this._context.QuestionSets.Remove(set);
                this._context.SaveChanges();
            }

            if (set is null)
                throw new NotFoundException($"Set with id {setId} not found.");
        }

        public void RemoveQuestionFromSets(RemoveQuestionsFromSetDto removeQuestionsFromSetDto)
        {
            var setId = removeQuestionsFromSetDto.SetId;

            var set = this._context.QuestionSets
                                .Include(qs => qs.QuestionSetMapping)
                                .FirstOrDefault(qs => qs.Id == setId);
            if (set is null)
                throw new NotFoundException($"Set with id {setId} not found.");

            List<int> questionIds = removeQuestionsFromSetDto.QuestionsId.ToList();

            var questionsToBeRemoved = set.QuestionSetMapping.Where(qsm => questionIds.Contains(qsm.QuestionId)).ToList();

            this._context.QuestionSetMapping.RemoveRange(questionsToBeRemoved);
            this._context.SaveChanges();
        }
        public void RemoveCourseFromUsers(RemoveCoursesFromUserDto removeCoursesFromUserDto)
        {
            var coursesToBeRemoved = removeCoursesFromUserDto.CoursesId;

            List<CoursesStudents> courseStudents = this._context.Students
                                    .Where(s => s.UserId == removeCoursesFromUserDto.UserId)
                                    .Include(s => s.CourseStudents)
                                    .Select(s => s.CourseStudents)
                                    .FirstOrDefault()
                                    .ToList();


            var csToBeRemoved = courseStudents
                                    .Where(cs => coursesToBeRemoved
                                    .Contains(cs.CourseDetailsId))
                                    .ToList();

            this._context.CoursesStudents.RemoveRange(csToBeRemoved);
            this._context.SaveChanges();
        }
        public void RemoveSetsFromCourse(RemoveSetsFromCourse removeSetsFromCourseDto)
        {
            var setsToBeRemoved = removeSetsFromCourseDto.SetsId;

            List<CoursesQuestionsSet> courseSets = this._context.CoursesQuestionsSets
                                    .Where(c => c.CourseDetailsId == removeSetsFromCourseDto.CourseId)
                                    .ToList();

            var ssToBeRemoved = courseSets
                                    .Where(cs => setsToBeRemoved
                                    .Contains(cs.QuestionSetId))
                                    .ToList();

            this._context.CoursesQuestionsSets.RemoveRange(ssToBeRemoved);
            this._context.SaveChanges();
        }
    }
}
