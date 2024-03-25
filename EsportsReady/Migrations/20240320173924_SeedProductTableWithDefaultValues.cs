using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsportsReady.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTableWithDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "AMD Ryzen™ 5 5600G, Radeon™ RX 580, 8GB (1 x 8GB) DDR4 2800 MHz, B450M DS3H Motherboard, 500GB M.2 NVME SSD, 550W Bronze PSU", 400, "Gaming PC 1" },
                    { 2, "AMD Ryzen™ 5 5600, Radeon™ RX 6650 XT, 16GB (2 x 8GB) DDR4 3000 MHz, B550M Motherboard, 1TB M.2 NVME, 550W Bronze PSU", 700, "Gaming PC 2" },
                    { 3, "Intel Core i5-13400F, Radeon™ RX 6800, B760M DS3H Motherboard, 16GB (2 x 8GB) DDR4-3200 MHz, 1TB M.2 NVME, 750W Gold PSU", 900, "Gaming PC 3" },
                    { 4, "Intel® Core™ i5-12600K, NVIDIA® GeForce RTX™ 3070, 32GB (4 x 8GB) DDR4 3200 MHz, B760 Motherboard, 1TB NVMe M.2 SSD, ATX 650W Gold PSU", 1200, "Gaming PC 4" },
                    { 5, "AMD Ryzen™ 7 5800X3D, NVIDIA® GeForce RTX™ 4070, 32GB (2 x 16GB) DDR4 3600 MHz, B650 Motherboard, 2TB NVMe M.2 SSD, SFX 850W Gold PSU", 1500, "Gaming PC 5" },
                    { 6, "AMD Ryzen™ 7 7800X3D, NVIDIA® GeForce RTX™ 4070 Ti, 64 GB (4 x 16GB) DDR4 3600 MHz, X670E Motherboard, 2TB NVMe M.2 SSD, 1000W Gold PSU", 2100, "Gaming PC 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
