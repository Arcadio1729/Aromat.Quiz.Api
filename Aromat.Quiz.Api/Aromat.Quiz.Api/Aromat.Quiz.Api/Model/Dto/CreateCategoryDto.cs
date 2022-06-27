using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class CreateCategoryDto
    {
        public string Degree  { get; set; }
        public string Level { get; set; }
        public string SubSubject { get; set; }
    }
}
