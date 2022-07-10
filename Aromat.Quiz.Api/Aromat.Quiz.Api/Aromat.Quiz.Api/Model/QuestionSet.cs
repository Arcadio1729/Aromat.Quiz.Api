using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class QuestionSet
    {
        public int Id { get; set; }

        public virtual List<CoursesQuestionsSet> CourseQuestionSets { get; set; }
        public virtual List<QuestionSetMapping> QuestionSetMapping { get; set; }
    }
}
