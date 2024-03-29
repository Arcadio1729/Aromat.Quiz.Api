﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class CoursesStudents
    {
        public int Id { get; set; }
        public int CourseDetailsId { get; set; }
        public int StudentsId { get; set; }
        public virtual CourseDetails CourseDetails { get; set; }
        public virtual Students Student { get; set; }
    }
}
