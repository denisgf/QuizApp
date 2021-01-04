using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Difficulties",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Description", "DifficultyName" },
                values: new object[] { 1, "easy", "Easy" });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Description", "DifficultyName" },
                values: new object[] { 2, "medium", "Medium" });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Description", "DifficultyName" },
                values: new object[] { 3, "hard", "Hard" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Description", "TypeName" },
                values: new object[] { 1, "multiple", "Multiple Choice" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Description", "TypeName" },
                values: new object[] { 2, "boolean", "True / False" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Difficulties");
        }
    }
}
