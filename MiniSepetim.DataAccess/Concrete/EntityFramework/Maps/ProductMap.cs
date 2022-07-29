using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x=>x.Price).HasColumnType("decimal");

            builder.HasMany(x => x.Pictures).WithOne(x => x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x => x.OrderDetails).WithOne(x=>x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
