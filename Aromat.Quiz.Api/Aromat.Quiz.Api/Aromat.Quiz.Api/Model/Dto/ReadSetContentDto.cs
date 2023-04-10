using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class ReadSetContentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<ReadQuestionDto> Items { get; set; }
    }
}
