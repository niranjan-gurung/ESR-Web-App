﻿using EsportsReady.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EsportsReady.Data
{
    public class ProductContext : IdentityDbContext
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
