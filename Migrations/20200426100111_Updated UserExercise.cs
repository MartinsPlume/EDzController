using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class UpdatedUserExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Roles_ExerciseId",
                table: "UserExercises");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Exercises_ExerciseId",
                table: "UserExercises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Roles_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
