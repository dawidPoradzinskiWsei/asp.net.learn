using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViewsGetter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "YearOfProduction" },
                values: new object[] { new DateTime(2024, 11, 5, 18, 4, 28, 245, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 11, 5, 18, 4, 28, 245, DateTimeKind.Local).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "YearOfProduction" },
                values: new object[] { new DateTime(2024, 11, 5, 18, 4, 28, 245, DateTimeKind.Local).AddTicks(1773), new DateTime(2024, 11, 5, 18, 4, 28, 245, DateTimeKind.Local).AddTicks(1771) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "YearOfProduction" },
                values: new object[] { new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8324), new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "YearOfProduction" },
                values: new object[] { new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8331), new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8328) });
        }
    }
}
