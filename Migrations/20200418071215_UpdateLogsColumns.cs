using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class UpdateLogsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Logs");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateTime",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDateTime",
                table: "Logs");

            migrationBuilder.AddColumn<DateTime>(
                name: "Name",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
