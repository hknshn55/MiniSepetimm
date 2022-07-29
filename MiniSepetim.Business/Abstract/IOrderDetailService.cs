using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetOrderDetailById(int orderId);
        Task OrderDetailAdd(OrderDetail orderDetail);
        Task OrderDetailUpdate(OrderDetail orderDetail);
        Task OrderDetailDeleteById(int orderId);
        Task<OrderDetail> OrderDetailWithOrderProduct(int orderId);
    }
}
