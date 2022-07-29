using AutoMapper;
using MiniSepetim.Business.Abstract;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderDal.Get(x=>x.Id == orderId);
        }

        public async Task OrderAdd(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            await _orderDal.Add(order);
        }

        public async Task OrderDeleteById(int id)
        {
            Order order = await GetOrderById(id);
        }

        public async Task<IList<Order>> OrderList()
        {
          return    await _orderDal.GetList();
        }

        public async Task<IList<Order>> OrderListByCustomerId(int customerId)
        {
            return await _orderDal.GetList(x => x.CustomerId == customerId);
        }

        public async Task OrderUpdate(Order order)
        {
            await _orderDal.Update(order);
        }
        public async Task<IList<Order>> OrderWithCustomer()
        {
            return await _orderDal.OrderWithCustomer();
        }
    }
}
