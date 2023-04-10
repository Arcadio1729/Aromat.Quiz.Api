using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class ReadSetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
