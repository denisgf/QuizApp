using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Migrations
{
    public partial class UpdateAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizName",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IsCorrectAnswer",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Statement",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "AnswerStatement",
                table: "Answers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerStatement",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "QuizName",
                table: "Quizzes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectAnswer",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Statement",
                table: "Answers",
                type: "TEXT",
                nullable: true);
        }
    }
}
