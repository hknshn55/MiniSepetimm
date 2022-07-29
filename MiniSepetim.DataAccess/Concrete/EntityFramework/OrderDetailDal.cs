
using Microsoft.EntityFrameworkCore;
using MiniSepetim.Core.DataAccess.EntityFramework;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Context;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework
{
    public class OrderDetailDal:RepositoryBase<OrderDetail>,IOrderDetailDal
    {
        public OrderDetailDal(MiniSepetimContext context):base(context)
        {

        }
        public async Task< OrderDetail> OrderDetailWithOrder(Expression<Func<OrderDetail,bool>> expression)
        {
            return await set.Include(x => x.Order).Include(x => x.Product).Where(expression).FirstOrDefaultAsync();
        }
    }
}
