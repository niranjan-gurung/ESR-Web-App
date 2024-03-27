using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsportsReady.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motherboard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSU = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "CPU", "GPU", "Memory", "Motherboard", "PSU", "ProductId", "Storage" },
                values: new object[,]
                {
                    { 1, "AMD Ryzen™ 5 5600G", "Radeon™ RX 580", "8GB (1 x 8GB) DDR4 2800 MHz", "B450M DS3H Motherboard", "550W Bronze", 1, "500GB M.2 NVME SSD" },
                    { 2, "AMD Ryzen™ 5 5600", "Radeon™ RX 6650 XT", "16GB (2 x 8GB) DDR4 3000 MHz", "B550M Motherboard", "550W Bronze", 2, "1TB M.2 NVME SSD" },
                    { 3, "Intel Core i5-13400F", "Radeon™ RX 6800", "16GB (2 x 8GB) DDR4 3200 MHz", "B760M DS3H Motherboard", "650W Gold", 3, "1TB M.2 NVME SSD" },
                    { 4, "Intel® Core™ i5-12600K", "NVIDIA® GeForce RTX™ 3070", "32GB (4 x 8GB) DDR4 3200 MHz", "B760M DS3H Motherboard", "750W Gold PSU", 4, "1TB M.2 NVMe SSD" },
                    { 5, "AMD Ryzen™ 7 5800X3D", "NVIDIA® GeForce RTX™ 4070", "32GB (2 x 16GB) DDR4 3600 MHz", "B650 Motherboard", "SFX 850W Gold", 5, "2TB M.2 NVMe SSD" },
                    { 6, "AMD Ryzen™ 7 7800X3D", "NVIDIA® GeForce RTX™ 4070 Ti", "64GB (4 x 16GB) DDR4 3600 MHz", "X670E Motherboard", "1000W Gold", 6, "2TB M.2 NVMe SSD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ProductId",
                table: "Descriptions",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "AMD Ryzen™ 5 5600G, Radeon™ RX 580, 8GB (1 x 8GB) DDR4 2800 MHz, B450M DS3H Motherboard, 500GB M.2 NVME SSD, 550W Bronze PSU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "AMD Ryzen™ 5 5600, Radeon™ RX 6650 XT, 16GB (2 x 8GB) DDR4 3000 MHz, B550M Motherboard, 1TB M.2 NVME, 550W Bronze PSU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Intel Core i5-13400F, Radeon™ RX 6800, B760M DS3H Motherboard, 16GB (2 x 8GB) DDR4-3200 MHz, 1TB M.2 NVME, 750W Gold PSU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Intel® Core™ i5-12600K, NVIDIA® GeForce RTX™ 3070, 32GB (4 x 8GB) DDR4 3200 MHz, B760 Motherboard, 1TB NVMe M.2 SSD, ATX 650W Gold PSU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "AMD Ryzen™ 7 5800X3D, NVIDIA® GeForce RTX™ 4070, 32GB (2 x 16GB) DDR4 3600 MHz, B650 Motherboard, 2TB NVMe M.2 SSD, SFX 850W Gold PSU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "AMD Ryzen™ 7 7800X3D, NVIDIA® GeForce RTX™ 4070 Ti, 64 GB (4 x 16GB) DDR4 3600 MHz, X670E Motherboard, 2TB NVMe M.2 SSD, 1000W Gold PSU");
        }
    }
}
