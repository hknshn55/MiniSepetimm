using MiniSepetim.Core.Entities;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class Product :IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }
        public bool State { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
