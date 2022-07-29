using AutoMapper;
using FluentValidation.Results;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Business.ValidationRules.FluentValidation;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.SellerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class SellerManager : ISellerService
    {
        private readonly ISellerDal _sellerDal;
        private readonly IMapper _mapper;
        SellerValidator rules = new SellerValidator();
        public ValidationResult Validator(Seller seller)
        {
            return rules.Validate(seller);
        }
        public SellerManager(ISellerDal sellerDal, IMapper mapper)
        {
            _sellerDal = sellerDal;
            _mapper = mapper;
        }

        public async Task<Seller> GetSellerById(int sellerId)
        {
            return await _sellerDal.Get(x=>x.Id == sellerId);
        }

        public async Task SellerAdd(SellerDto sellerDto)
        {
            Seller seller = _mapper.Map<Seller>(sellerDto);
            var result = Validator(seller);
            if (result.IsValid)
            {
                await _sellerDal.Add(seller);
            }
            
        }
        public async Task SellerDeleteById(int sellerId)
        {
            Seller seller = await GetSellerById(sellerId);
            await _sellerDal.Delete(seller);
        }

        public async Task<IList<Seller>> SellerList()
        {
            return await _sellerDal.GetList();
        }

        public async Task<IList<Seller>> SellerListByName(string sellerName)
        {
            return await _sellerDal.GetList(x=>x.Name == sellerName);
        }

        public async Task SellerUpdate(Seller seller)
        {
            var result = Validator(seller);
            if (result.IsValid)
            {
                await _sellerDal.Update(seller);
            }
        }
    }
}
