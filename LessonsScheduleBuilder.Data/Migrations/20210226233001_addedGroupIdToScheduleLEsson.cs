using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsScheduleBuilder.Data.Migrations
{
    public partial class addedGroupIdToScheduleLEsson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleLessons_Groups_GroupId",
                table: "ScheduleLessons");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "ScheduleLessons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleLessons_Groups_GroupId",
                table: "ScheduleLessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleLessons_Groups_GroupId",
                table: "ScheduleLessons");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "ScheduleLessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleLessons_Groups_GroupId",
                table: "ScheduleLessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
