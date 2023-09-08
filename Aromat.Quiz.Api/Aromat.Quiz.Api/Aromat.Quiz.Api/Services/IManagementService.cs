using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using System.Collections.Generic;

namespace Aromat.Quiz.Api.Services
{
    public interface IManagementService
    {
        void AddStudentToTeacher(List<TeacherStudentDto> teacherStudentsDto);
        void RemoveStudentFromTeacher(int teacherId, int studentId);
    }
}
