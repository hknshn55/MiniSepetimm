using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class Picture:IEntity
    {
        public Picture()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public bool  State { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
