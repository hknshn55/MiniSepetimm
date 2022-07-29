using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework.Maps
{
    public class SellerMap : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(60);

            builder.HasMany(x => x.Products).WithOne(x => x.Seller).HasForeignKey(x => x.SellerId);
            builder.HasOne(x => x.AppIdentityUser).WithOne(x => x.Seller).HasPrincipalKey<AppIdentityUser>(x=>x.Id);
        }
    }
}
