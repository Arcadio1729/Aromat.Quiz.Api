﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Answer
    {
        [Required]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Required]
        public bool Correct { get; set; }
        public string LatexContent { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
