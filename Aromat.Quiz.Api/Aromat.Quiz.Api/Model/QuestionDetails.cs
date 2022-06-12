using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class QuestionDetails
    {
        [Required]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SubSubjectId { get; set; }
        public int UniqueId { get; set; }
    }
}
