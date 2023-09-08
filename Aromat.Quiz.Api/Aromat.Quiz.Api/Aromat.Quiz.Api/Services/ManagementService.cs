using Aromat.Quiz.Api.Exceptions;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Aromat.Quiz.Api.Services
{
    public class ManagementService : IManagementService
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapping;
        public ManagementService(QuizDbContext context, IMapper mapping)
        {
            this._context = context;
            this._mapping = mapping;
        }
        public void AddStudentToTeacher(List<TeacherStudentDto> teacherStudentsDto)
        {
            this._context.TeacherStudents
                .AddRange(teacherStudentsDto
                .Select(ts => new TeacherStudent
                    {
                        TeacherId = ts.TeacherId,
                        StudentId = ts.StudentId
                    })
                );

            this._context.SaveChanges();
        }

        public void RemoveStudentFromTeacher(int teacherId, int studentId)
        {
            var teacherStudent = this._context.TeacherStudents
                                    .Where(ts=>ts.TeacherId== teacherId && ts.StudentId== studentId)
                                    .FirstOrDefault();

            if(teacherStudent==null)
                throw new NotFoundException($"Student {studentId} not found for for {teacherId}.");

            this._context.TeacherStudents.Remove(teacherStudent);
            this._context.SaveChanges();
        }
    }
}
