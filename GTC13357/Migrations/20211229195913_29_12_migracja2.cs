using Microsoft.EntityFrameworkCore.Migrations;

namespace GTC13357.Migrations
{
    public partial class _29_12_migracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTitles_Course_Title_Id",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Course_Title_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Course_Title_Id",
                table: "Courses");

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

            migrationBuilder.AddColumn<int>(
                name: "Course_Title_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Course_Title_Id",
                table: "Courses",
                column: "Course_Title_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTitles_Course_Title_Id",
                table: "Courses",
                column: "Course_Title_Id",
                principalTable: "CourseTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
