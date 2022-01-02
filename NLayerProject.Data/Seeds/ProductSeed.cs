using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    class ProductSeed :IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;


        public ProductSeed(int[] Ids)
        {
            _ids = Ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Needle Pen", Price = 45.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Pencil", Price = 12.50m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Pen", Price = 32.50m, Stock = 300, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Little Notebook", Price = 10.75m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "MiddleNotebook", Price = 12.50m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Big Notebook", Price = 32.50m, Stock = 100, CategoryId = _ids[1] }
                );



        }
    }
}
