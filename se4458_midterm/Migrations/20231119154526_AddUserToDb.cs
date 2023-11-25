using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace se4458_midterm.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "12345", "testUser" },
                    { 2, "98765", "RealUser" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AvailableSeats", "Capacity", "Departure", "DepartureDate", "Destination", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { 1, 50, 100, "Boston", new DateTime(2023, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "New York", 4428, 50.0 },
                    { 2, 4, 200, "Berlin", new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", 5626, 60.0 }
                });
        }
    }
}
