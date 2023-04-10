using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class RemoveSetsFromCourse
    {
        public int CourseId { get; set; }
        public List<int> SetsId { get; set; }
    }
}
