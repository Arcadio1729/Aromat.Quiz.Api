using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class categorychange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDetails_Categories_CategoryId",
                table: "QuestionsDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsDetails_QuestionId",
                table: "QuestionsDetails");

            migrationBuilder.DropColumn(
                name: "SubSubjectId",
                table: "QuestionsDetails");

            migrationBuilder.DropColumn(
                name: "SchooldDegree",
                table: "Degrees");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueId",
                table: "QuestionsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "QuestionsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageContent",
                table: "Questions",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolDegree",
                table: "Degrees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDetails_QuestionId",
                table: "QuestionsDetails",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsDetails_Categories_CategoryId",
                table: "QuestionsDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDetails_Categories_CategoryId",
                table: "QuestionsDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsDetails_QuestionId",
                table: "QuestionsDetails");

            migrationBuilder.DropColumn(
                name: "SchoolDegree",
                table: "Degrees");

            migrationBuilder.AlterColumn<int>(
                name: "UniqueId",
                table: "QuestionsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "QuestionsDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubSubjectId",
                table: "QuestionsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImageContent",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchooldDegree",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDetails_QuestionId",
                table: "QuestionsDetails",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsDetails_Categories_CategoryId",
                table: "QuestionsDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
