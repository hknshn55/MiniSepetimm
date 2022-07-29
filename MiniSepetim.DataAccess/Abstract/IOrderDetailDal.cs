
using MiniSepetim.Core.DataAccess;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Abstract
{
    public interface IOrderDetailDal:IRepository<OrderDetail>
    {
        Task<OrderDetail> OrderDetailWithOrder(Expression<Func<OrderDetail, bool>> expression);
    }
}
