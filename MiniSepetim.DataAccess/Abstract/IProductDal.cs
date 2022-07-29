
using MiniSepetim.Core.DataAccess;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Abstract
{
    public interface IProductDal:IRepository<Product>
    {

        Task<IList<Product>> ProductWithCategory();




        Task<ProductDetailDto> ProductWithSellerAndCategory(Product product);
        Task<IList<ProductPictureDto>> ProductPictureList();
        Task<Product> ProductDetails(int productId);


    }
}
