using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<IList<Customer>> CustomerListByName(string customerName);
        Task<IList<Customer>> CustomerList();
        Task<IList<Customer>> CustomerListByState(bool customerState);
        Task CustomerAdd(CustomerDto customerDto);
        Task CustomerUpdate(Customer customer);
        Task CustomerDelete(int customerId);
    }
}
