using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    [Table("Aromat_CategoryDetails_View")]
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string SchoolDegree { get; set; }
        public string Level { get; set; }
        public string Subject { get; set; }
    }
}
