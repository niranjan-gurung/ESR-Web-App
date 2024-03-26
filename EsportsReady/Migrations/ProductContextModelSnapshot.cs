﻿// <auto-generated />
using EsportsReady.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EsportsReady.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EsportsReady.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "AMD Ryzen™ 5 5600G, Radeon™ RX 580, 8GB (1 x 8GB) DDR4 2800 MHz, B450M DS3H Motherboard, 500GB M.2 NVME SSD, 550W Bronze PSU",
                            Image = "~/images/PCs/pc1.jpg",
                            Price = 400,
                            Title = "Gaming PC 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "AMD Ryzen™ 5 5600, Radeon™ RX 6650 XT, 16GB (2 x 8GB) DDR4 3000 MHz, B550M Motherboard, 1TB M.2 NVME, 550W Bronze PSU",
                            Image = "~/images/PCs/pc2.jpg",
                            Price = 700,
                            Title = "Gaming PC 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Intel Core i5-13400F, Radeon™ RX 6800, B760M DS3H Motherboard, 16GB (2 x 8GB) DDR4-3200 MHz, 1TB M.2 NVME, 750W Gold PSU",
                            Image = "~/images/PCs/pcred.jpg",
                            Price = 900,
                            Title = "Gaming PC 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Intel® Core™ i5-12600K, NVIDIA® GeForce RTX™ 3070, 32GB (4 x 8GB) DDR4 3200 MHz, B760 Motherboard, 1TB NVMe M.2 SSD, ATX 650W Gold PSU",
                            Image = "~/images/PCs/pcblue.jpg",
                            Price = 1200,
                            Title = "Gaming PC 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "AMD Ryzen™ 7 5800X3D, NVIDIA® GeForce RTX™ 4070, 32GB (2 x 16GB) DDR4 3600 MHz, B650 Motherboard, 2TB NVMe M.2 SSD, SFX 850W Gold PSU",
                            Image = "~/images/PCs/pcgreen.jpg",
                            Price = 1500,
                            Title = "Gaming PC 5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "AMD Ryzen™ 7 7800X3D, NVIDIA® GeForce RTX™ 4070 Ti, 64 GB (4 x 16GB) DDR4 3600 MHz, X670E Motherboard, 2TB NVMe M.2 SSD, 1000W Gold PSU",
                            Image = "~/images/PCs/pcwhite.jpg",
                            Price = 2100,
                            Title = "Gaming PC 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
