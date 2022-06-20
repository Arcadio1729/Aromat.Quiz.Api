using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class CreateAnswerDto
    {
        public int LatexContent { get; set; }
        public byte[] ImageContent { get; set; }
        public bool Correct { get; set; }
    }
}
