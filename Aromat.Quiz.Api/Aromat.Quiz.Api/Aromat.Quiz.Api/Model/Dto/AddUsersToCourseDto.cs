using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class AddUsersToCourseDto
    {
        public int CourseId { get; set; }
        public List<UserDto> UsersDto { get; set; }
    }
}
