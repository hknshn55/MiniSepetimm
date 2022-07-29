using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Concrete
{
    public class AppIdentityUser:IdentityUser<int>
    {
        public virtual Customer Customer { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
