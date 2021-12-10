using Microsoft.EntityFrameworkCore.Migrations;

namespace GTC13357.Migrations
{
    public partial class dodanyCourseTitleMigracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_Author_Surname",
                table: "CourseTitles",
                newName: "Author_Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author_Surname",
                table: "CourseTitles",
                newName: "_Author_Surname");
        }
    }
}
