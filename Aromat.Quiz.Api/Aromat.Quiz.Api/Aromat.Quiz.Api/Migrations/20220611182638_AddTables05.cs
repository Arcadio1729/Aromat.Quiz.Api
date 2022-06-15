using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class AddTables05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Subjects_SubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Categories",
                newName: "SubSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubSubjectId",
                table: "Categories",
                column: "SubSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SubSubjects_SubSubjectId",
                table: "Categories",
                column: "SubSubjectId",
                principalTable: "SubSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubSubjects_SubSubjectId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubSubjectId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "SubSubjectId",
                table: "Categories",
                newName: "SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectId",
                table: "Subjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Subjects_SubjectId",
                table: "Subjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
