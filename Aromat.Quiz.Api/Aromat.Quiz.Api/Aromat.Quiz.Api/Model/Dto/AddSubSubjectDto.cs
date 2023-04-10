using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class AddSubSubjectDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubSubjectName { get; set; }
    }
}
