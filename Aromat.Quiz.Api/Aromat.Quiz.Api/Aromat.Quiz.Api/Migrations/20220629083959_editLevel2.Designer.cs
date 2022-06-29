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
    [Migration("20220629083959_editLevel2")]
    partial class editLevel2
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

                    b.Property<byte[]>("ImageContent")
                        .HasColumnType("varbinary(max)");

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

                    b.HasOne("Aromat.Quiz.Api.Model.SubSubject", null)
                        .WithMany("Categories")
                        .HasForeignKey("SubSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Aromat.Quiz.Api.Model.SubSubject", b =>
                {
                    b.HasOne("Aromat.Quiz.Api.Model.Subject", null)
                        .WithMany("SubSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
