﻿// <auto-generated />
using System;
using Aromat.Upload.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aromat.Upload.Api.Migrations
{
    [DbContext(typeof(UploadDbContext))]
    [Migration("20220619203430_BuildNewDb")]
    partial class BuildNewDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aromat.Upload.Api.Model.FileData", b =>
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

                    b.ToTable("FilesData");
                });

            modelBuilder.Entity("Aromat.Upload.Api.Model.FileDetails", b =>
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

            modelBuilder.Entity("Aromat.Upload.Api.Model.FileData", b =>
                {
                    b.HasOne("Aromat.Upload.Api.Model.FileDetails", "FileDetails")
                        .WithMany()
                        .HasForeignKey("FileDetailsId");

                    b.Navigation("FileDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
