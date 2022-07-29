using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Maps;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework.Context
{
    public class MiniSepetimContext:IdentityDbContext<AppIdentityUser,AppIdentityRole,int>
    {
        public MiniSepetimContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().HasKey(x => new { x.ProductId, x.OrderId });
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new PictureMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new SellerMap());
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers{ get; set; }
        public virtual DbSet<Order> Orders  { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails  { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Picture>  Pictures { get; set; }
    }
}
