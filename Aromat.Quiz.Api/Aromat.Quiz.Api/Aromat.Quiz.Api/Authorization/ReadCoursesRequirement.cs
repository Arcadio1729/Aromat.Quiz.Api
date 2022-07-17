using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Authorization
{
    public class ReadCoursesRequirement : IAuthorizationRequirement
    {
        public int MinimumCoursesAssigned { get; set; } = 2;
    }
}
