using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
          

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

           // builder.HasOne<Category>(x => x.Category).WithMany(p => p.Products).HasForeignKey("Id");

            builder.Property(x =>x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("Decimal(18,2)");

            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            builder.ToTable("Products");
        }
    }
}
