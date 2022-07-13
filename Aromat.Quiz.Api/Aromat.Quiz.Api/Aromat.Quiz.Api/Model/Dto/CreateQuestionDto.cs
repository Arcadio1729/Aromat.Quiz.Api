using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class CreateQuestionDto
    {
        public string LatexContent { get; set; }
        public int QuestionImageId { get; set; }
        public string Subject { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string Level { get; set; }
        public bool TestQuestion { get; set; }
    }
}
