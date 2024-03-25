using EsportsReady.Models;
using Microsoft.EntityFrameworkCore;

namespace EsportsReady.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        // seed the table with some arbitrary data...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Title = "Gaming PC 1", 
                    Price = 400,
                    Description = "AMD Ryzen™ 5 5600G, Radeon™ RX 580, 8GB (1 x 8GB) DDR4 2800 MHz, B450M DS3H Motherboard, 500GB M.2 NVME SSD, 550W Bronze PSU"
                },
                new Product
                {
                    Id = 2,
                    Title = "Gaming PC 2",
                    Price = 700,
                    Description = "AMD Ryzen™ 5 5600, Radeon™ RX 6650 XT, 16GB (2 x 8GB) DDR4 3000 MHz, B550M Motherboard, 1TB M.2 NVME, 550W Bronze PSU"
                },
                new Product
                {
                    Id = 3,
                    Title = "Gaming PC 3",
                    Price = 900,
                    Description = "Intel Core i5-13400F, Radeon™ RX 6800, B760M DS3H Motherboard, 16GB (2 x 8GB) DDR4-3200 MHz, 1TB M.2 NVME, 750W Gold PSU"
                },
                new Product
                {
                    Id = 4,
                    Title = "Gaming PC 4",
                    Price = 1200,
                    Description = "Intel® Core™ i5-12600K, NVIDIA® GeForce RTX™ 3070, 32GB (4 x 8GB) DDR4 3200 MHz, B760 Motherboard, 1TB NVMe M.2 SSD, ATX 650W Gold PSU"
                },
                new Product
                {
                    Id = 5,
                    Title = "Gaming PC 5",
                    Price = 1500,
                    Description = "AMD Ryzen™ 7 5800X3D, NVIDIA® GeForce RTX™ 4070, 32GB (2 x 16GB) DDR4 3600 MHz, B650 Motherboard, 2TB NVMe M.2 SSD, SFX 850W Gold PSU"
                },
                new Product
                {
                    Id = 6,
                    Title = "Gaming PC 6",
                    Price = 2100,
                    Description = "AMD Ryzen™ 7 7800X3D, NVIDIA® GeForce RTX™ 4070 Ti, 64 GB (4 x 16GB) DDR4 3600 MHz, X670E Motherboard, 2TB NVMe M.2 SSD, 1000W Gold PSU"
                }
            );
        }
    }
}
