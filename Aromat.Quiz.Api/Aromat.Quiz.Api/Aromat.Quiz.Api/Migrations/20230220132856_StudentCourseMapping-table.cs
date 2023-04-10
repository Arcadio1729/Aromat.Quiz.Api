using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class StudentCourseMappingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FileData_FileDetails_FileDetailsId",
            //    table: "FileData");

            //migrationBuilder.DropIndex(
            //    name: "IX_FileData_FileDetailsId",
            //    table: "FileData");

            //migrationBuilder.DropColumn(
            //    name: "FileDetailsId",
            //    table: "FileData");

            migrationBuilder.CreateTable(
                name: "StudentCourseMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    CourseDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourseMapping_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseMapping_CourseDetailsId",
                table: "StudentCourseMapping",
                column: "CourseDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourseMapping");

            migrationBuilder.AddColumn<int>(
                name: "FileDetailsId",
                table: "FileData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileData_FileDetailsId",
                table: "FileData",
                column: "FileDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileData_FileDetails_FileDetailsId",
                table: "FileData",
                column: "FileDetailsId",
                principalTable: "FileDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
