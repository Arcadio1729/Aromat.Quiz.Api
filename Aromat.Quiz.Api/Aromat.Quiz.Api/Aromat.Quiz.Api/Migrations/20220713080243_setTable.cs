using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class setTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QuestionSets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FileDataId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions",
                column: "FileDataId",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QuestionSets");

            migrationBuilder.AlterColumn<int>(
                name: "FileDataId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_FileData_FileDataId",
                table: "Questions",
                column: "FileDataId",
                principalTable: "FileData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
