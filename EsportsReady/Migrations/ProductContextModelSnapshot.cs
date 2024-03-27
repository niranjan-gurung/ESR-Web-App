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

            modelBuilder.Entity("EsportsReady.Models.Description", b =>
                {
                    b.Property<int>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DescriptionId"));

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motherboard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DescriptionId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Descriptions");

                    b.HasData(
                        new
                        {
                            DescriptionId = 1,
                            CPU = "AMD Ryzen™ 5 5600G",
                            GPU = "Radeon™ RX 580",
                            Memory = "8GB (1 x 8GB) DDR4 2800 MHz",
                            Motherboard = "B450M DS3H Motherboard",
                            PSU = "550W Bronze",
                            ProductId = 1,
                            Storage = "500GB M.2 NVME SSD"
                        },
                        new
                        {
                            DescriptionId = 2,
                            CPU = "AMD Ryzen™ 5 5600",
                            GPU = "Radeon™ RX 6650 XT",
                            Memory = "16GB (2 x 8GB) DDR4 3000 MHz",
                            Motherboard = "B550M Motherboard",
                            PSU = "550W Bronze",
                            ProductId = 2,
                            Storage = "1TB M.2 NVME SSD"
                        },
                        new
                        {
                            DescriptionId = 3,
                            CPU = "Intel Core i5-13400F",
                            GPU = "Radeon™ RX 6800",
                            Memory = "16GB (2 x 8GB) DDR4 3200 MHz",
                            Motherboard = "B760M DS3H Motherboard",
                            PSU = "650W Gold",
                            ProductId = 3,
                            Storage = "1TB M.2 NVME SSD"
                        },
                        new
                        {
                            DescriptionId = 4,
                            CPU = "Intel® Core™ i5-12600K",
                            GPU = "NVIDIA® GeForce RTX™ 3070",
                            Memory = "32GB (4 x 8GB) DDR4 3200 MHz",
                            Motherboard = "B760M DS3H Motherboard",
                            PSU = "750W Gold PSU",
                            ProductId = 4,
                            Storage = "1TB M.2 NVMe SSD"
                        },
                        new
                        {
                            DescriptionId = 5,
                            CPU = "AMD Ryzen™ 7 5800X3D",
                            GPU = "NVIDIA® GeForce RTX™ 4070",
                            Memory = "32GB (2 x 16GB) DDR4 3600 MHz",
                            Motherboard = "B650 Motherboard",
                            PSU = "SFX 850W Gold",
                            ProductId = 5,
                            Storage = "2TB M.2 NVMe SSD"
                        },
                        new
                        {
                            DescriptionId = 6,
                            CPU = "AMD Ryzen™ 7 7800X3D",
                            GPU = "NVIDIA® GeForce RTX™ 4070 Ti",
                            Memory = "64GB (4 x 16GB) DDR4 3600 MHz",
                            Motherboard = "X670E Motherboard",
                            PSU = "1000W Gold",
                            ProductId = 6,
                            Storage = "2TB M.2 NVMe SSD"
                        });
                });

            modelBuilder.Entity("EsportsReady.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Image = "~/images/PCs/pc1.jpg",
                            Price = 400,
                            Title = "Gaming PC 1"
                        },
                        new
                        {
                            Id = 2,
                            Image = "~/images/PCs/pc2.jpg",
                            Price = 700,
                            Title = "Gaming PC 2"
                        },
                        new
                        {
                            Id = 3,
                            Image = "~/images/PCs/pcred.jpg",
                            Price = 900,
                            Title = "Gaming PC 3"
                        },
                        new
                        {
                            Id = 4,
                            Image = "~/images/PCs/pcblue.jpg",
                            Price = 1200,
                            Title = "Gaming PC 4"
                        },
                        new
                        {
                            Id = 5,
                            Image = "~/images/PCs/pcgreen.jpg",
                            Price = 1500,
                            Title = "Gaming PC 5"
                        },
                        new
                        {
                            Id = 6,
                            Image = "~/images/PCs/pcwhite.jpg",
                            Price = 2100,
                            Title = "Gaming PC 6"
                        });
                });

            modelBuilder.Entity("EsportsReady.Models.Description", b =>
                {
                    b.HasOne("EsportsReady.Models.Product", null)
                        .WithOne("Description")
                        .HasForeignKey("EsportsReady.Models.Description", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EsportsReady.Models.Product", b =>
                {
                    b.Navigation("Description")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
