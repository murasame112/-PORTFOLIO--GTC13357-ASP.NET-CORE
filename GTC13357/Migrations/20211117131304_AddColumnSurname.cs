using Microsoft.EntityFrameworkCore.Migrations;

namespace GTC13357.Migrations
{
    public partial class AddColumnSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Courses",
                newName: "Name");
        }
    }
}
