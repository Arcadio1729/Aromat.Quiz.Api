using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class CreateTables03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Categories_CategoryId",
                table: "Degrees");

            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Categories_CategoryId",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Levels_CategoryId",
                table: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_CategoryId",
                table: "Degrees");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Degrees");

            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DegreeId",
                table: "Categories",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LevelId",
                table: "Categories",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubjectId",
                table: "Categories",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Degrees_DegreeId",
                table: "Categories",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Levels_LevelId",
                table: "Categories",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Subjects_SubjectId",
                table: "Categories",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Degrees_DegreeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Levels_LevelId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Subjects_SubjectId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DegreeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LevelId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubjectId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Levels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Degrees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_CategoryId",
                table: "Levels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_CategoryId",
                table: "Degrees",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Categories_CategoryId",
                table: "Degrees",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Categories_CategoryId",
                table: "Levels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
