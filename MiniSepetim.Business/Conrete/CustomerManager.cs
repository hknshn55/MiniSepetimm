using AutoMapper;
using FluentValidation.Results;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Business.ValidationRules.FluentValidation;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        CustomerValidator rules = new CustomerValidator();
        public ValidationResult Validator(Customer customer)
        {
            return rules.Validate(customer);
        }
        public CustomerManager(IMapper mapper,ICustomerDal customerDal)
        {
            _mapper = mapper;
            _customerDal = customerDal;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerDal.Get(x => x.Id == id);
        }

        public async Task<IList<Customer>> CustomerListByName(string customerName)
        {
            return await _customerDal.GetList(x=>x.FirstName ==customerName);
        }

        public async Task<IList<Customer>> CustomerList()
        {
            return await _customerDal.GetList();
        }

        public async Task<IList<Customer>> CustomerListByState(bool customerState)
        {
            return await _customerDal.GetList(x=>x.State == customerState);
        }

        public async Task CustomerAdd(CustomerDto customerDto)
        {

            Customer customer = _mapper.Map<Customer>(customerDto);
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.Add(customer);
            }
           
        }

        public async Task CustomerUpdate(Customer customer)
        {
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.Add(customer);
            }
        }

        public async Task CustomerDelete(int customerId)
        {
             var customer= await GetCustomerById(customerId);
            await _customerDal.Delete(customer);
        }

       
    }
}
