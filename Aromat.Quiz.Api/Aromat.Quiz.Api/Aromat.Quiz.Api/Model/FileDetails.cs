﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class FileDetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int FileId { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
    }
}
