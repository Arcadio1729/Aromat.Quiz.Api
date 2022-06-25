using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class emptyforview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Answers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageContent",
                table: "Answers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatexContent",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "LatexContent",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
