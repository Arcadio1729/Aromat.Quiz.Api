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
        public int SubjectId { get; set; }
        public int DegreeId { get; set; }
    }
}
