using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.SellerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface ISellerService
    {
        Task<Seller> GetSellerById(int sellerId);
        Task<IList<Seller>> SellerList();
        Task<IList<Seller>> SellerListByName(string sellerName);
        Task SellerAdd(SellerDto sellerDto);
        Task SellerUpdate(Seller seller);
        Task SellerDeleteById(int sellerId);
    }
}
