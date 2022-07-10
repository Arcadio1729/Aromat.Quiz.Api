using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CoursesStudents> CourseStudents { get; set; }
    }
}
