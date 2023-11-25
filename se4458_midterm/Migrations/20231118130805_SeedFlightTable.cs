using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace se4458_midterm.Migrations
{
    /// <inheritdoc />
    public partial class SeedFlightTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AvailableSeats", "Capacity", "Departure", "Destination", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { 1, 50, 100, new DateTime(2023, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified), "New York", 4428, 50.0 },
                    { 2, 4, 200, new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", 5626, 60.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
