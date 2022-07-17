using Aromat.Quiz.Api.Model;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Authorization
{
    public class ReadCoursesRequirementHandler : AuthorizationHandler<ReadCoursesRequirement>
    {
        private readonly QuizDbContext _context;

        public ReadCoursesRequirementHandler(QuizDbContext context)
        {
            this._context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadCoursesRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier).Value);

            return Task.CompletedTask;
        }
    }
}
