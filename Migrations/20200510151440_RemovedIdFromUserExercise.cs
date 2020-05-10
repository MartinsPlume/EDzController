using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class RemovedIdFromUserExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
