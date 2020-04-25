using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class EDzDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Logs",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<DateTime>()
                },
                constraints: table => { table.PrimaryKey("PK_Logs", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 255),
                    Password = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "UserLogs",
                table => new
                {
                    UserId = table.Column<int>(),
                    LogId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => new {x.UserId, x.LogId});
                    table.ForeignKey(
                        "FK_UserLogs_Logs_LogId",
                        x => x.LogId,
                        "Logs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserLogs_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserRoles",
                table => new
                {
                    UserId = table.Column<int>(),
                    RoleId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_UserRoles_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserRoles_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_UserLogs_LogId",
                "UserLogs",
                "LogId");

            migrationBuilder.CreateIndex(
                "IX_UserRoles_RoleId",
                "UserRoles",
                "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "UserLogs");

            migrationBuilder.DropTable(
                "UserRoles");

            migrationBuilder.DropTable(
                "Logs");

            migrationBuilder.DropTable(
                "Roles");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}