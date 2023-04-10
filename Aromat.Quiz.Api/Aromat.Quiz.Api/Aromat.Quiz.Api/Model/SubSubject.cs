using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class SubSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
