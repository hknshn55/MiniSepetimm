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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25) ;
            builder.Property(x=>x.PhoneNumber).HasMaxLength(11);
            builder.Property(x=>x.Adress).HasMaxLength(50);

            //İlişkiler 
            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x=>x.CustomerId);
            builder.HasOne(x => x.AppIdentityUser).WithOne(x => x.Customer).HasPrincipalKey<AppIdentityUser>(x=>x.Id);
        }
    }
}
