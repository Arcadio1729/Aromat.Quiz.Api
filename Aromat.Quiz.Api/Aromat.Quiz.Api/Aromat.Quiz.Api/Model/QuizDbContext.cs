﻿using Aromat.Quiz.Api.Model.Dto;
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
        //private readonly string _connectionString = "Server=Localhost;User=LAPTOP-FAABQ3F4\\arcad;Database=AromatDb;Trusted_Connection=True;";
        private readonly string _connectionString = "Server=ADU;User=arcadio;Database=Aromat;Password=pass1;Trusted_Connection=True;";

        public DbSet<Level> Levels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubSubject> SubSubjects { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionDetails> QuestionsDetails { get; set; }
        public DbSet<Answer> Answers { get; set; }


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
        public virtual DbSet<CategoryDetails> CategoryDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategoryDetails>(cd =>
                {
                    cd.HasNoKey();
                    cd.ToView("CategoryDetailsView");
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }
    }
}
