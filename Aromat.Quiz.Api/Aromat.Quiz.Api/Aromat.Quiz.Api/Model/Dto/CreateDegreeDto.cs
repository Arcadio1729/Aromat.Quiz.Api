using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class CreateDegreeDto
    {
        [RegularExpression("^SP$|^GM$|^LO$|^SW$")]
        public string School { get; set; }

        public string SchoolDegree { get; set; }

        public string Description { get; set; }
    }
}
