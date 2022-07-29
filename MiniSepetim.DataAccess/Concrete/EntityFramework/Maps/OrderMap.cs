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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CustomerId).IsRequired();

            builder.HasMany(x => x.OrderDetails).WithOne(x=>x.Order).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
