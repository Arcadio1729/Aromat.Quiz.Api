using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class CreateDegreeDto
    {
        public string School { get; set; }
        public string SchoolDegree { get; set; }
        public string Description { get; set; }
    }
}
