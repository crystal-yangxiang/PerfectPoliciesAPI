using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPolicies.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2,
                column: "OptionIsCorrect",
                value: false);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "OptionIsCorrect",
                value: false);

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "OptionIsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[] { 4, false, "d. ", "Melbourne", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserInfoId",
                keyValue: 1,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "PerfectPolicies!22", "AdminPerfectPolicies" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2,
                column: "OptionIsCorrect",
                value: true);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "OptionIsCorrect",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserInfoId",
                keyValue: 1,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "abc_1234", "Yang" });
        }
    }
}
