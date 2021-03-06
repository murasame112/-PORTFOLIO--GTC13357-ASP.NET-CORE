using Microsoft.EntityFrameworkCore.Migrations;

namespace GTC13357.Migrations
{
    public partial class dodanyCourseTitleMigracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Author_Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCourseTitle",
                columns: table => new
                {
                    CourseTitlesId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourseTitle", x => new { x.CourseTitlesId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CourseCourseTitle_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourseTitle_CourseTitles_CourseTitlesId",
                        column: x => x.CourseTitlesId,
                        principalTable: "CourseTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourseTitle_CoursesId",
                table: "CourseCourseTitle",
                column: "CoursesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourseTitle");

            migrationBuilder.DropTable(
                name: "CourseTitles");
        }
    }
}
