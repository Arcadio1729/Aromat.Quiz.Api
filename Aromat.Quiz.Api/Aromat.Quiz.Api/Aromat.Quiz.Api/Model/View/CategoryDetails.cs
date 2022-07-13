using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.View
{
    [Keyless]
    public class CategoryDetails
    {
        public string Degree { get; set; }
        public string School { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
        public int CategoryId { get; set; }
    }
}
