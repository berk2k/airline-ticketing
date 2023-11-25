using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace se4458_midterm.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSQLDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AvailableSeats", "Capacity", "Departure", "DepartureDate", "Destination", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { 3, 5, 100, "Berlin", new DateTime(2023, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", 6550, 50.0 },
                    { 4, 50, 100, "Boston", new DateTime(2023, 6, 1, 10, 40, 0, 0, DateTimeKind.Unspecified), "New York", 3328, 40.0 },
                    { 5, 50, 100, "Tokyo", new DateTime(2023, 10, 2, 10, 40, 0, 0, DateTimeKind.Unspecified), "Toronto", 2233, 140.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", "admin", "admin", "se4458_admin" },
                    { 2, "passenger", "12345", "passenger", "se4458_passenger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
