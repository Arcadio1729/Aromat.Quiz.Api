using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class view01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"Create View dbo.CategoryDetailsView as
                            (
	                            Select
	                            dbo.Categories.DegreeId,
	                            dbo.Categories.LevelId,
	                            dbo.SubSubjects.SubjectId,
                                dbo.Categories.Id as 'CategoryId',
	                            dbo.Levels.Name as 'Level',
	                            dbo.Degrees.Description as 'Degree',
	                            dbo.SubSubjects.Name as 'Subject'
	                            from dbo.Categories
	                            join Levels on Levels.Id=dbo.Categories.LevelId
	                            join Degrees on Degrees.Id=dbo.Degrees.Id
	                            join dbo.SubSubjects on dbo.SubSubjects.Id = dbo.Categories.SubSubjectId
                            )";

            migrationBuilder.Sql(@"DROP VIEW CategoryDetailsView");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
