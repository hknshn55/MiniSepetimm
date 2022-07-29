using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class Order : IEntity
    {
        public Order()
        {
            CreateDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
