using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Entities;
using NLayerProject.Data.Configurations;
using NLayerProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {              
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            // builder.ApplyConfigurationsFromAssembly(GetType().Assembly); // That's best practice and it will get all classes which used IEntityTypeConfiguration.

            //modelBuilder.Entity<Product>().Ignore(x => x.Category);
            //modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey("CategoryId");
           // modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(c => c.Category).HasForeignKey("Id");

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        


    }
}
