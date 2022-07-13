using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class changeQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "FileDataId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FileDataId",
                table: "Questions",
                column: "FileDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions",
                column: "FileDataId",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FileDataId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FileDataId",
                table: "Questions");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageContent",
                table: "Questions",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
