using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsportsReady.Migrations
{
    /// <inheritdoc />
    public partial class modelBuilderExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 3,
                column: "Motherboard",
                value: "B650 DS3H Motherboard");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 4,
                column: "Motherboard",
                value: "B650M DS3H Motherboard");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 5,
                column: "Motherboard",
                value: "B760M Motherboard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 3,
                column: "Motherboard",
                value: "B760M DS3H Motherboard");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 4,
                column: "Motherboard",
                value: "B760M DS3H Motherboard");

            migrationBuilder.UpdateData(
                table: "Descriptions",
                keyColumn: "DescriptionId",
                keyValue: 5,
                column: "Motherboard",
                value: "B650 Motherboard");
        }
    }
}
