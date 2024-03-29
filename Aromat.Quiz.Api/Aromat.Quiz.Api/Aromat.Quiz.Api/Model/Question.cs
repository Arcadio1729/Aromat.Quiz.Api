﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Question
    {
        [Required]
        public int Id { get; set; }
        public int FileDataId { get; set; }

        public string Content { get; set; }
        public string LatexContent { get; set; }

        public bool QuizQuestion { get; set; }

        [Column("ImageId")]
        public virtual FileData FileData { get; set; }
        public virtual QuestionDetails QuestionsDetails { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<QuestionSetMapping> QuestionSetMapping { get; set; }
    }
}
