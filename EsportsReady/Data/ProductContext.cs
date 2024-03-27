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
        public DbSet<Description> Descriptions { get; set; }

        // seed the table with some arbitrary data...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>().HasData(
                new Description()
                {
                    DescriptionId = 1,
                    ProductId = 1,
                    CPU = "AMD Ryzen™ 5 5600G",
                    GPU = "Radeon™ RX 580",
                    Memory = "8GB (1 x 8GB) DDR4 2800 MHz",
                    Motherboard = "B450M DS3H Motherboard",
                    Storage = "500GB M.2 NVME SSD",
                    PSU = "550W Bronze"
                },
                new Description()
                {
                    DescriptionId = 2,
                    ProductId = 2,
                    CPU = "AMD Ryzen™ 5 5600",
                    GPU = "Radeon™ RX 6650 XT",
                    Memory = "16GB (2 x 8GB) DDR4 3000 MHz",
                    Motherboard = "B550M Motherboard",
                    Storage = "1TB M.2 NVME SSD",
                    PSU = "550W Bronze"
                },
                new Description()
                {
                    DescriptionId = 3,
                    ProductId = 3,
                    CPU = "Intel Core i5-13400F",
                    GPU = "Radeon™ RX 6800",
                    Memory = "16GB (2 x 8GB) DDR4 3200 MHz",
                    Motherboard = "B760M DS3H Motherboard",
                    Storage = "1TB M.2 NVME SSD",
                    PSU = "650W Gold"
                },
                new Description()
                {
                    DescriptionId = 4,
                    ProductId = 4,
                    CPU = "Intel® Core™ i5-12600K",
                    GPU = "NVIDIA® GeForce RTX™ 3070",
                    Memory = "32GB (4 x 8GB) DDR4 3200 MHz",
                    Motherboard = "B760M DS3H Motherboard",
                    Storage = "1TB M.2 NVMe SSD",
                    PSU = "750W Gold PSU"
                },
                new Description()
                {
                    DescriptionId = 5,
                    ProductId = 5,
                    CPU = "AMD Ryzen™ 7 5800X3D",
                    GPU = "NVIDIA® GeForce RTX™ 4070",
                    Memory = "32GB (2 x 16GB) DDR4 3600 MHz",
                    Motherboard = "B650 Motherboard",
                    Storage = "2TB M.2 NVMe SSD",
                    PSU = "SFX 850W Gold"
                },
                new Description()
                {
                    DescriptionId = 6,
                    ProductId = 6,
                    CPU = "AMD Ryzen™ 7 7800X3D",
                    GPU = "NVIDIA® GeForce RTX™ 4070 Ti",
                    Memory = "64GB (4 x 16GB) DDR4 3600 MHz",
                    Motherboard = "X670E Motherboard",
                    Storage = "2TB M.2 NVMe SSD",
                    PSU = "1000W Gold"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Title = "Gaming PC 1",
                    Image = "~/images/PCs/pc1.jpg",
                    Price = 400,
                    //Description = new Description()
                    //{ 
                    //    CPU = "AMD Ryzen™ 5 5600G",
                    //    GPU = "Radeon™ RX 580",
                    //    Memory = "8GB (1 x 8GB) DDR4 2800 MHz", 
                    //    Motherboard = "B450M DS3H Motherboard", 
                    //    Storage = "500GB M.2 NVME SSD",
                    //    PSU = "550W Bronze" 
                    //}
                },
                new Product
                {
                    Id = 2,
                    Title = "Gaming PC 2",
                    Image = "~/images/PCs/pc2.jpg",
                    Price = 700,
                    //Description = new Description()
                    //{
                    //    CPU = "AMD Ryzen™ 5 5600",
                    //    GPU = "Radeon™ RX 6650 XT",
                    //    Memory = "16GB (2 x 8GB) DDR4 3000 MHz",
                    //    Motherboard = "B550M Motherboard",
                    //    Storage = "1TB M.2 NVME SSD",
                    //    PSU = "550W Bronze"
                    //}
                },
                new Product
                {
                    Id = 3,
                    Title = "Gaming PC 3",
                    Image = "~/images/PCs/pcred.jpg",
                    Price = 900,
                    //Description = new Description()
                    //{
                    //    CPU = "Intel Core i5-13400F",
                    //    GPU = "Radeon™ RX 6800",
                    //    Memory = "16GB (2 x 8GB) DDR4 3200 MHz",
                    //    Motherboard = "B760M DS3H Motherboard",
                    //    Storage = "1TB M.2 NVME SSD",
                    //    PSU = "650W Gold"
                    //}

                },
                new Product
                {
                    Id = 4,
                    Title = "Gaming PC 4",
                    Image = "~/images/PCs/pcblue.jpg",
                    Price = 1200,
                    //Description = new Description()
                    //{
                    //    CPU = "Intel® Core™ i5-12600K",
                    //    GPU = "NVIDIA® GeForce RTX™ 3070",
                    //    Memory = "32GB (4 x 8GB) DDR4 3200 MHz",
                    //    Motherboard = "B760M DS3H Motherboard",
                    //    Storage = "1TB M.2 NVMe SSD",
                    //    PSU = "750W Gold PSU"
                    //}
                },
                new Product
                {
                    Id = 5,
                    Title = "Gaming PC 5",
                    Image = "~/images/PCs/pcgreen.jpg",
                    Price = 1500,
                    //Description = new Description()
                    //{
                    //    CPU = "AMD Ryzen™ 7 5800X3D",
                    //    GPU = "NVIDIA® GeForce RTX™ 4070",
                    //    Memory = "32GB (2 x 16GB) DDR4 3600 MHz",
                    //    Motherboard = "B650 Motherboard",
                    //    Storage = "2TB M.2 NVMe SSD",
                    //    PSU = "SFX 850W Gold"
                    //}
                },
                new Product
                {
                    Id = 6,
                    Title = "Gaming PC 6",
                    Image = "~/images/PCs/pcwhite.jpg",
                    Price = 2100,
                    //Description = new Description()
                    //{
                    //    CPU = "AMD Ryzen™ 7 7800X3D",
                    //    GPU = "NVIDIA® GeForce RTX™ 4070 Ti",
                    //    Memory = "64GB (4 x 16GB) DDR4 3600 MHz",
                    //    Motherboard = "X670E Motherboard",
                    //    Storage = "2TB M.2 NVMe SSD",
                    //    PSU = "1000W Gold"
                    //}
                }
            );
        }
    }
}
