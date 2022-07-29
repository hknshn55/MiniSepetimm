using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class Customer : IEntity 
    {
        public Customer()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public bool State { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual AppIdentityUser AppIdentityUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
