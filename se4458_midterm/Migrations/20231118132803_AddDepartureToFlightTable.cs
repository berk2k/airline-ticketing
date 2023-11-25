using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace se4458_midterm.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartureToFlightTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Departure",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Departure", "DepartureDate" },
                values: new object[] { "Boston", new DateTime(2023, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Departure", "DepartureDate" },
                values: new object[] { "Berlin", new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Flights");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Departure",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "Departure",
                value: new DateTime(2023, 6, 1, 7, 47, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "Departure",
                value: new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
