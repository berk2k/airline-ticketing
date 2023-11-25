using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace se4458_midterm.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserSQLDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[] { 1, "admin", "admin", "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[] { 3, "admin", "admin", "admin", "admin" });
        }
    }
}
