using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class OrderDetail : IEntity 
    {
        public OrderDetail()
        {
            CreateDate = DateTime.Now;
        }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
