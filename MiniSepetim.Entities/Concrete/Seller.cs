using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class Seller : IEntity
    {
        public Seller()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual AppIdentityUser AppIdentityUser { get; set; }
    }
}
