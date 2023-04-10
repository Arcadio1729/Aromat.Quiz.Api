using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class StudentCourseMappingtabledrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetailsStudentCourseMapping");

            migrationBuilder.DropTable(
                name: "StudentCourseMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCourseMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseMapping", x => x.Id);
                });

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
    }
}
