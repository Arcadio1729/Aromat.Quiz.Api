using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class CoursesQuestionsSet
    {
        public int Id { get; set; }
        public int CourseDetailsId { get; set; }
        public int QuestionSetId { get; set; }
    }
}
