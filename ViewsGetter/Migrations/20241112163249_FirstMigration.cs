using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ViewsGetter.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

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
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganzationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_computers_Organizations_OrganzationId",
                        column: x => x.OrganzationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address_City", "Address_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Krakow", "Kurczakow", "2131212", "XKOM", "2984395734" },
                    { 102, "Krakow", "Centralna", "4353443", "MORELE", "11123395734" }
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Category", "Created", "Gpu", "Name", "OrganzationId", "Processor", "Producer", "RamGB", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 11, 12, 17, 32, 48, 974, DateTimeKind.Local).AddTicks(4686), "RTX4070Super", "SuperPc", 101, "i5-12400", "Asus", 16, new DateTime(2024, 11, 12, 17, 32, 48, 974, DateTimeKind.Local).AddTicks(4640) },
                    { 2, 2, new DateTime(2024, 11, 12, 17, 32, 48, 974, DateTimeKind.Local).AddTicks(4692), "RTX4070Super", "SuperPc", 102, "i5-12400", "Asus", 16, new DateTime(2024, 11, 12, 17, 32, 48, 974, DateTimeKind.Local).AddTicks(4690) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_computers_OrganzationId",
                table: "computers",
                column: "OrganzationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
