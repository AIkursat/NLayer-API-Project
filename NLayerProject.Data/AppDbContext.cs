﻿using Microsoft.EntityFrameworkCore;
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
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }


    }
}
