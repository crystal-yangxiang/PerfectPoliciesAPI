using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPolicies.Migrations
{
    public partial class addnewuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoId", "Password", "UserName" },
                values: new object[] { 2, "abc_1234", "Yang" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserInfoId",
                keyValue: 2);
        }
    }
}
