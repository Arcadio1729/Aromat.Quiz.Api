﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class Degree
    {
        [Required]
        public int Id { get; set; }
        [RegularExpression("[^Szkoła Podstawowa$|^Gimnazjum$|^Liceum$|^Studia$]")]
        public string School { get; set; }
        public string SchoolDegree { get; set; }
        public string Description { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
