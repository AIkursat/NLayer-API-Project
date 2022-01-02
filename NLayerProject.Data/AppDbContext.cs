using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Entities;
using NLayerProject.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data
{
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {              
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
