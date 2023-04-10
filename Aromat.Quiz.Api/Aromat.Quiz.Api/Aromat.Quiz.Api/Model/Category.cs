using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Category
    {
        public int Id { get; set; }
        public int LevelId { get; set; }
        public int SubSubjectId { get; set; }
        public int DegreeId { get; set; }

        public virtual Level Level { get; set; }
        public virtual SubSubject Subject { get; set; }
        public virtual Degree Degree { get; set; }

        public virtual List<QuestionDetails> QuestionsDetails { get; set; }
    }
}
