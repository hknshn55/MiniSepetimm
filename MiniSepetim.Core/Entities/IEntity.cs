using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Core.Entities
{
    public interface IEntity
    {
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }
    }
}
