using Aromat.Quiz.Api.Model.Authentication;
using Aromat.Quiz.Api.Model.Dto;
using Aromat.Quiz.Api.Model.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class QuizDbContext : DbContext
    {

        public DbSet<Level> Levels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubSubject> SubSubjects { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionDetails> QuestionsDetails { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }

        #region Courses
        public DbSet<QuestionSet> QuestionSets { get; set; }
        public DbSet<QuestionSetMapping> QuestionSetMapping { get; set; }
        public DbSet<CoursesQuestionsSet> CoursesQuestionsSets { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<CoursesStudents> CoursesStudents { get; set; }
        public DbSet<Students> Students { get; set; }
        #endregion

        #region Files
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<FileData> FileData { get; set; }

        #endregion

        #region Authentication
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }

        public virtual DbSet<CategoryDetails> CategoryDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategoryDetails>(cd =>
                {
                    cd.HasNoKey();
                    cd.ToView("CategoryDetailsView");
                });

            modelBuilder
                .Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder
                .Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }



    }
}
