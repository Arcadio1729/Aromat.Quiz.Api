using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class QuizDbContext : DbContext
    {
        private readonly string _connectionString = "Server=Localhost;User=LAPTOP-FAABQ3F4\\arcad;Database=AromatDb;Trusted_Connection=True;";

        public DbSet<Level> Levels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }
    }
}
