using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class CourseDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<CoursesStudents> CourseStudents { get; set; }
        public virtual List<CoursesQuestionsSet> CourseQuestionSets { get; set; }
    }
}
