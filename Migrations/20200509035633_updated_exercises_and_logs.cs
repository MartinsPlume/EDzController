using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class updated_exercises_and_logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ExerciseCode",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "UserInfo",
                table: "Logs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfo",
                table: "Logs");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExerciseCode",
                table: "Exercises",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
