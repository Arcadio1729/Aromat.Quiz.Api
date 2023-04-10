using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class RemoveQuestionsFromSetDto
    {
            public int SetId { get; set; }
            public List<int> QuestionsId { get; set; }
    }
}
