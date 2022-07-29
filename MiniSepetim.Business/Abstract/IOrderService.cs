using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Task<IList<Order>> OrderListByCustomerId(int customerId);
        Task<IList<Order>> OrderList();
        Task OrderAdd(OrderDto orderDto);
        Task OrderUpdate(Order order);
        Task OrderDeleteById(int id);
        Task<IList<Order>> OrderWithCustomer();


    }
}
