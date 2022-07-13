using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromat.Quiz.Api.Migrations
{
    public partial class view1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            CREATE OR ALTER VIEW [dbo].[CategoryDetailsView] AS
                Select
                    Levels.Name as Level,
                    Degrees.School as School,
                    Degrees.SchoolDegree as Degree,
                    SubSubjects.Name as Subject,
                    Categories.Id as CategoryId
                    from 
                    Categories
                    join Levels on Categories.LevelId=Levels.Id
                    join SubSubjects on Categories.SubSubjectId=SubSubjects.Id
                    join Degrees on Categories.DegreeId=Degrees.Id";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW CategoryDetailsView");
        }
    }
}
