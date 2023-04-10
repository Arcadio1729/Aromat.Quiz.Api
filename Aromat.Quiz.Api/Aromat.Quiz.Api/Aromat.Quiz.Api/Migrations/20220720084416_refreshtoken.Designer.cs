﻿// <auto-generated />
using System;
using Aromat.Quiz.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aromat.Quiz.Api.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20220720084416_refreshtoken")]
    partial class refreshtoken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ImageContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LatexContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DegreeId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("SubSubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("LevelId");

                    b.HasIndex("SubSubjectId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CourseDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseDetails");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CoursesQuestionsSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseDetailsId");

                    b.HasIndex("QuestionSetId");

                    b.ToTable("CoursesQuestionsSets");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CoursesStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseDetailsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CoursesStudents");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolDegree")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.FileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("FileDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileDetailsId");

                    b.ToTable("FileData");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.FileDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileDetails");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileDataId")
                        .HasColumnType("int");

                    b.Property<string>("LatexContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("QuizQuestion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FileDataId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("QuestionsDetails");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionSets");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionSetMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionSetId");

                    b.ToTable("QuestionSetMapping");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.SubSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubSubjects");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.View.CategoryDetails", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("CategoryDetailsView");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Answer", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.RefreshToken", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Authentication.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.User", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Authentication.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Category", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Degree", null)
                        .WithMany("Categories")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.Level", null)
                        .WithMany("Categories")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.SubSubject", null)
                        .WithMany("Categories")
                        .HasForeignKey("SubSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CoursesQuestionsSet", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.CourseDetails", null)
                        .WithMany("CourseQuestionSets")
                        .HasForeignKey("CourseDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.QuestionSet", null)
                        .WithMany("CourseQuestionSets")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CoursesStudents", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.CourseDetails", null)
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.Students", null)
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.FileData", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.FileDetails", "FileDetails")
                        .WithMany()
                        .HasForeignKey("FileDetailsId");

                    b.Navigation("FileDetails");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Question", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.FileData", "FileData")
                        .WithMany()
                        .HasForeignKey("FileDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileData");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionDetails", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Category", null)
                        .WithMany("QuestionsDetails")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.Question", null)
                        .WithOne("QuestionsDetails")
                        .HasForeignKey("Aromat.Quiz.Api.Model.QuestionDetails", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionSetMapping", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Question", null)
                        .WithMany("QuestionSetMapping")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aromat.Quiz.Api.Model.QuestionSet", null)
                        .WithMany("QuestionSetMapping")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Students", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.SubSubject", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Subject", null)
                        .WithMany("SubSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Authentication.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Category", b =>
                {
                    b.Navigation("QuestionsDetails");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.CourseDetails", b =>
                {
                    b.Navigation("CourseQuestionSets");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Degree", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Level", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionsDetails");

                    b.Navigation("QuestionSetMapping");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionSet", b =>
                {
                    b.Navigation("CourseQuestionSets");

                    b.Navigation("QuestionSetMapping");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Students", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.SubSubject", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Subject", b =>
                {
                    b.Navigation("SubSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
