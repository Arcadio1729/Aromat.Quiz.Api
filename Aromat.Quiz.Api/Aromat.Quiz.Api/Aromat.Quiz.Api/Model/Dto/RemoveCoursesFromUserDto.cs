using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class RemoveCoursesFromUserDto
    {
        public int UserId { get; set; }
        public List<int> CoursesId { get; set; }
    }
}
