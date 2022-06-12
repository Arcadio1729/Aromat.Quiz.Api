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
    [Migration("20220611182341_AddTables04")]
    partial class AddTables04
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

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
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

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("LevelId");

                    b.ToTable("Categories");
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

                    b.Property<int>("SchooldDegree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("ImageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatexContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("QuizQuestion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SubSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionsDetails");
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

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Answer", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.QuestionDetails", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Category", null)
                        .WithMany("QuestionsDetails")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Aromat.Quiz.Api.Model.Question", null)
                        .WithMany("QuestionsDetails")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Subject", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Subject", null)
                        .WithMany("SubSubjects")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Category", b =>
                {
                    b.Navigation("QuestionsDetails");
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
                });

            modelBuilder.Entity("Aromat.Quiz.Api.Model.Subject", b =>
                {
                    b.Navigation("SubSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
