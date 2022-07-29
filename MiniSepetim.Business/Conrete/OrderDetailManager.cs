using AutoMapper;
using MiniSepetim.Business.Abstract;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IMapper _mapper;
        public OrderDetailManager(IOrderDetailDal orderDetailDal, IMapper mapper)
        {
            _orderDetailDal = orderDetailDal;
            _mapper = mapper;
        }

        public async Task<OrderDetail> GetOrderDetailById(int orderId)
        {
            return await _orderDetailDal.Get(x=>x.OrderId == orderId);
        }

        public async Task OrderDetailAdd(OrderDetail orderDetail)
        {
            await _orderDetailDal.Add(orderDetail);
        }


        public async Task OrderDetailDeleteById(int orderId)
        {
            var order = await GetOrderDetailById(orderId);
            await _orderDetailDal.Delete(order);
        }

        public async Task<IList<OrderDetail>> OrderDetailListByOrderId(int orderId)
        {
            return await _orderDetailDal.GetList(x=>x.OrderId == orderId);
        }

        public async Task OrderDetailUpdate(OrderDetail orderDetail)
        {
            await _orderDetailDal.Update(orderDetail);
        }

        public async Task<OrderDetail> OrderDetailWithOrderProduct(int orderId)
        {
            return await _orderDetailDal.OrderDetailWithOrder(x=>x.OrderId == orderId);
        }
    }
}
