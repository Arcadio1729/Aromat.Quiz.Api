using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class ReadQuestionDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string Degree { get; set; }
        public string Level { get; set; }
    }
}
