using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class seededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 24, 19, 26, 38, 977, DateTimeKind.Utc).AddTicks(2970), "CSK" },
                    { 2, new DateTime(2025, 2, 24, 19, 26, 38, 977, DateTimeKind.Utc).AddTicks(2970), "LSG" },
                    { 3, new DateTime(2025, 2, 24, 19, 26, 38, 977, DateTimeKind.Utc).AddTicks(2970), "MI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);
        }
    }
}
