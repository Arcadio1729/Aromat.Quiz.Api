using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class QuestionSetMapping
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int QuestionSetId { get; set; }
    }
}
