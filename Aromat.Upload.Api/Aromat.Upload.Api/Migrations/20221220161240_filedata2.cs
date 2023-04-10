using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Upload.Api.Migrations
{
    public partial class filedata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_FilesData_FileDetails_FileDetailsId",
               table: "FilesData");


            migrationBuilder.DropPrimaryKey(
                name: "PK_FilesData",
                table: "FilesData");

        }
    }
}
