using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class StudentCourseMappingtablevirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseMapping_CourseDetails_CourseDetailsId",
                table: "StudentCourseMapping");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseMapping_CourseDetailsId",
                table: "StudentCourseMapping");

            migrationBuilder.CreateTable(
                name: "CourseDetailsStudentCourseMapping",
                columns: table => new
                {
                    CourseDetailsId = table.Column<int>(type: "int", nullable: false),
                    StudentCoursesMappingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetailsStudentCourseMapping", x => new { x.CourseDetailsId, x.StudentCoursesMappingId });
                    table.ForeignKey(
                        name: "FK_CourseDetailsStudentCourseMapping_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDetailsStudentCourseMapping_StudentCourseMapping_StudentCoursesMappingId",
                        column: x => x.StudentCoursesMappingId,
                        principalTable: "StudentCourseMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsStudentCourseMapping_StudentCoursesMappingId",
                table: "CourseDetailsStudentCourseMapping",
                column: "StudentCoursesMappingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetailsStudentCourseMapping");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseMapping_CourseDetailsId",
                table: "StudentCourseMapping",
                column: "CourseDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseMapping_CourseDetails_CourseDetailsId",
                table: "StudentCourseMapping",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
