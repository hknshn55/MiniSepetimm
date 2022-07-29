
using Microsoft.EntityFrameworkCore;
using MiniSepetim.Core.DataAccess.EntityFramework;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Context;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework
{
    public class OrderDal:RepositoryBase<Order>,IOrderDal
    {
        public OrderDal(MiniSepetimContext context):base(context)
        {

        }
        public async Task<IList<Order>> OrderWithCustomer()
        {
            return await set.Include(x => x.Customer).Include(x=>x.OrderDetails).Where(x=>x.State == true).ToListAsync();
        }
    }
}
