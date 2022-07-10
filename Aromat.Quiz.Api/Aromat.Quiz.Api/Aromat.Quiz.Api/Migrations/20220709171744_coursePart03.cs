using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class coursePart03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionSetId",
                table: "QuestionSetMapping",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesQuestionsSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: true),
                    QuestionSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesQuestionsSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesQuestionsSets_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursesQuestionsSets_QuestionSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursesStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: true),
                    StudentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesStudents_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursesStudents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSetMapping_QuestionSetId",
                table: "QuestionSetMapping",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesQuestionsSets_CourseDetailsId",
                table: "CoursesQuestionsSets",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesQuestionsSets_QuestionSetId",
                table: "CoursesQuestionsSets",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesStudents_CourseDetailsId",
                table: "CoursesStudents",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesStudents_StudentsId",
                table: "CoursesStudents",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSetMapping_QuestionSets_QuestionSetId",
                table: "QuestionSetMapping",
                column: "QuestionSetId",
                principalTable: "QuestionSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSetMapping_QuestionSets_QuestionSetId",
                table: "QuestionSetMapping");

            migrationBuilder.DropTable(
                name: "CoursesQuestionsSets");

            migrationBuilder.DropTable(
                name: "CoursesStudents");

            migrationBuilder.DropTable(
                name: "QuestionSets");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_QuestionSetMapping_QuestionSetId",
                table: "QuestionSetMapping");

            migrationBuilder.DropColumn(
                name: "QuestionSetId",
                table: "QuestionSetMapping");
        }
    }
}
