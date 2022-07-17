using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api
{
    public class QuizSeeder
    {
        private readonly QuizDbContext _context;

        public QuizSeeder(QuizDbContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            if (this._context.Database.CanConnect())
            {
                if (!this._context.Roles.Any())
                {
                    this._context.Roles.AddRange(new List<Role>()
                    {
                        new Role
                        {
                            Name = "Admin"
                        },
                        new Role
                        {
                            Name = "Student"
                        }
                    });
                    this._context.SaveChanges();
                }

            }
        }
    }
}
