﻿using Aromat.Quiz.Api.Exceptions;
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

            var c = this._context.QuestionSetMapping.Where(qsm => qsm.QuestionSetId == setId)
                    .Include(qsm => qsm.Question)
                    .Include(qsm => qsm.Question.QuestionsDetails);

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

        public string GetSetName(int setId)
        {
            return this._context.QuestionSets.FirstOrDefault(s => s.Id == setId).Name;
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
            var studentId = this._context.Students.FirstOrDefault(s => s.UserId == courseStudent.UserId).Id;

            CoursesStudents cs = new CoursesStudents
            {
                CourseDetailsId = courseStudent.CourseId,
                StudentsId = studentId
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

        public void AddUsersStudent(AddUsersToCourseDto addUsersToCourseDto)
        {
            List<CoursesStudents> coursesStudents = new List<CoursesStudents>();
            var courseId = addUsersToCourseDto.CourseId;
            coursesStudents = addUsersToCourseDto.UsersDto
                    .Select(x =>
                        new CoursesStudents
                        {
                            CourseDetailsId = courseId,
                            StudentsId = this._context.Students.Where(s => s.UserId == x.UserId).Select(s => s.Id).FirstOrDefault()
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

        #region user service
        public string ReadCoursesByUser(ClaimsPrincipal user)
        {
            var userId = int.Parse(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var role = ((ClaimsIdentity)user.Identity).Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value)
                            .FirstOrDefault();

            if (role == "Admin" || role == "Teacher")
            {
                return this.ReadCourses();
            }

            return this.ReadCoursesByUser(userId);
        }
        public string ReadCoursesByUser(int userId)
        {
            var studentId = this._context.Students.FirstOrDefault(s => s.UserId == userId).Id;

            List<CourseDetails> coursesStudent = this._context
                        .CoursesStudents
                        .Where(cs => cs.StudentsId == studentId)
                        .Select(cs => cs.CourseDetails)
                        .ToList();

            List<ReadCourseDto> coursesDto = coursesStudent
                                            .Select(cs => new ReadCourseDto
                                                {
                                                    Id = cs.Id,
                                                    Name = cs.Name
                                                })
                                            .ToList();

            var json = JsonConvert.SerializeObject(coursesDto);
            return json;
        }
        public string ReadSetsByUser(ClaimsPrincipal user,int courseId)
        {
            var userId = int.Parse(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            int cid = courseId;
            var role = ((ClaimsIdentity)user.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .FirstOrDefault();

            CoursesStudents course = new CoursesStudents();
            CourseDetails fullCourse;

            if (role == "Admin" || role=="Teacher")
            {
                //fullCourse = this._context.CoursesQuestionsSets
                //    .Where(cqs => cqs.CourseDetailsId == courseId)
                //    .FirstOrDefault();

                if(courseId == -1)
                {
                    fullCourse = this._context.CourseDetails.FirstOrDefault();
                }
                else
                {
                    fullCourse = this._context.CourseDetails
                                .Where(cd => cd.Id == courseId)
                                .FirstOrDefault();
                }

                if (fullCourse != null)
                {
                    if (courseId == -1)
                    {
                        var sets = this.ReadSets();
                        return sets;
                    }
                    else
                    {
                        var sets = this.ReadSets(fullCourse.Id);
                        return sets;
                    }
                }
                else
                {
                    throw new NotFoundException($"Course with id {courseId} not found DB.");
                }
            }
            else
            {
                var studentId = this._context.Students.FirstOrDefault(u => u.UserId == userId).Id;
                course = this._context.CoursesStudents
                    .Where(cs => cs.CourseDetailsId == courseId && cs.StudentsId == studentId)
                    .FirstOrDefault();
            }


            if (course != null)
            {
                var sets = this.ReadSets(course.CourseDetailsId);
                return sets;
            }
            else
            {
                throw new NotFoundException($"Course with id {courseId} not found for user {userId}.");
            }

        }
        public string ReadQuestionsByUser(int courseId, int setId, int userId)
        {
            var studentId = this._context.Students.FirstOrDefault(u => u.UserId == userId).Id;
            var course = this._context.CoursesStudents
                .Where(cs => cs.CourseDetailsId == courseId && cs.StudentsId == studentId)
                .FirstOrDefault();

            if (course != null)
            {
                var set = this._context.CoursesQuestionsSets
                    .Where(cqs => cqs.QuestionSetId == setId && cqs.CourseDetailsId == courseId)
                    .FirstOrDefault();

                if(set != null)
                {
                    var questions = this._context.QuestionSetMapping
                                        .Where(q => q.QuestionSetId == setId)
                                        .Include(qd => qd.Question.QuestionsDetails)
                                        .Include(c => c.Question.QuestionsDetails.Category)
                                        .Select(q => new ReadQuestionDto
                                        {
                                            Content = q.Question.Content,
                                            Degree = q.Question.QuestionsDetails.Category.Degree.Description,
                                            Level = q.Question.QuestionsDetails.Category.Level.Description,
                                            Image = q.Question.FileData.Data,
                                            Subject = q.Question.QuestionsDetails.Category.Subject.Name,
                                            Id = q.QuestionId
                                        })
                                        .ToList();

                    var json = JsonConvert.SerializeObject(questions);
                    return json;
                }
                else
                {
                    throw new NotFoundException($"Set with id {setId} not found for user {userId}.");
                }
            }
            else
            {
                throw new NotFoundException($"Course with id {courseId} not found for user {userId}.");
            }
        }
        
        #endregion
    }
}
