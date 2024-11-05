using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ViewsGetter.Migrations
{
    /// <inheritdoc />
    public partial class EFComputerSerivce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Processor = table.Column<string>(type: "TEXT", nullable: false),
                    RamGB = table.Column<int>(type: "INTEGER", nullable: false),
                    Gpu = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    YearOfProduction = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Category", "Created", "Gpu", "Name", "Processor", "Producer", "RamGB", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8324), "RTX4070Super", "SuperPc", "i5-12400", "Asus", 16, new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8274) },
                    { 2, 2, new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8331), "RTX4070Super", "SuperPc", "i5-12400", "Asus", 16, new DateTime(2024, 11, 5, 18, 3, 35, 450, DateTimeKind.Local).AddTicks(8328) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");
        }
    }
}
