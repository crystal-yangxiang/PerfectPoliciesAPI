using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPolicies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizCreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionIsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "PassPercentage", "QuizCreatedDate", "QuizCreatorName", "QuizTitle", "QuizTopic" },
                values: new object[] { 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Jones from Steve's Warehouse", "Steve's Warehouse Policy Quiz", "Working at Heights" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "PassPercentage", "QuizCreatedDate", "QuizCreatorName", "QuizTitle", "QuizTopic" },
                values: new object[] { 2, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Jones from Steve's Warehouse", "Steve's Warehouse Policy Quiz", "Copyright" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "PassPercentage", "QuizCreatedDate", "QuizCreatorName", "QuizTitle", "QuizTopic" },
                values: new object[] { 3, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yang Xiang", "How well do you know Australia?", "Geography" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionImageUrl", "QuestionText", "QuestionTopic", "QuizId" },
                values: new object[] { 1, null, "When looking to work at heights, I need to review:", "Working at Heights", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionImageUrl", "QuestionText", "QuestionTopic", "QuizId" },
                values: new object[] { 2, null, "With copyright material form our client:", "Copyright", 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionImageUrl", "QuestionText", "QuestionTopic", "QuizId" },
                values: new object[] { 3, null, "The capital of Australia is::", "Geography", 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "OptionIsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[] { 1, true, "a. ", "Canberra", 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "OptionIsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[] { 2, true, "b. ", "Brisbane", 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "OptionIsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[] { 3, true, "c. ", "Sydney", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
