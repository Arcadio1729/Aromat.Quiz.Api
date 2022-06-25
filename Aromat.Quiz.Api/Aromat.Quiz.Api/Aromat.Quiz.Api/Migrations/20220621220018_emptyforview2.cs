using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class emptyforview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
	                        CREATE VIEW Aromat_CategoryDetails_View AS
                            (
	                            Select 
	                            dbo.Categories.Id as 'CategoryId',
	                            dbo.Degrees.SchooldDegree as 'SchoolDegree',
	                            dbo.Levels.Name as 'Level',
	                            dbo.SubSubjects.Name as 'Subject' 
	                            from dbo.Categories
	                            join dbo.Degrees on dbo.Categories.DegreeId=dbo.Degrees.Id
	                            join dbo.Levels on dbo.Categories.LevelId=dbo.Levels.Id
	                            join dbo.SubSubjects on dbo.Categories.SubSubjectId=dbo.SubSubjects.Id
                            );");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
