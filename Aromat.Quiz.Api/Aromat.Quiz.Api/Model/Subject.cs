using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}
