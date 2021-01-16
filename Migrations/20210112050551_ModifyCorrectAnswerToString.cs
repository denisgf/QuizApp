using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Migrations
{
    public partial class ModifyCorrectAnswerToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerAnswerId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CorrectAnswerAnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerAnswerId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerAnswerId",
                table: "Questions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAnswerAnswerId",
                table: "Questions",
                column: "CorrectAnswerAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerAnswerId",
                table: "Questions",
                column: "CorrectAnswerAnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
