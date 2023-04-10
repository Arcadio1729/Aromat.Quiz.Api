using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class AddCoursesToUserDto
    {
        public int UserId { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
