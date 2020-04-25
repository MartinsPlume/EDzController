using Microsoft.EntityFrameworkCore.Migrations;

namespace EDzController.Migrations
{
    public partial class AddedExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ExerciseCode = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    ExercisePicture = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ExerciseVideo = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "UserExercises",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercises", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_UserExercises_Roles_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "UserExercises");
        }
    }
}
