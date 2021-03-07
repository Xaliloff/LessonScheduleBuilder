using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsScheduleBuilder.Data.Migrations
{
    public partial class initial33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field3",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field3",
                table: "Groups");
        }
    }
}
