using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.View
{
    [Table("Categories_Details_View")]
    public class CategoryDetailsView
    {
        [Key]
        public int CategoryId { get; set; }
        public string Level { get; set; }
        public string Degree { get; set; }
        public string Subsubject { get; set; }
    }
}
