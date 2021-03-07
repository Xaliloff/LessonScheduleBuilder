using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonsScheduleBuilder.Data.Migrations
{
    public partial class addedField2ToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "ScheduleLessons",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "ScheduleLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Field2",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "ScheduleLessons");

            migrationBuilder.DropColumn(
                name: "Field2",
                table: "Groups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ScheduleLessons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
