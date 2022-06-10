using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Category
    {
        public int Id { get; set; }

        public virtual List<Level> Levels { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Degree> Degrees { get; set; }
    }
}
