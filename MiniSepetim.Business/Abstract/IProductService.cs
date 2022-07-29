using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface IProductService
    {
        Task<IList<Product>> ProductWithCategory();
        Task<IList<ProductPictureDto>> ProductPictureList();
        Task<ProductDetailDto> ProductDetail(int id);
        Task<Product> GetProductById(int id);
        Task<IList<Product>> GetListProduct();
        Task<IList<Product>> GetListProductByName(string productName);
        Task<IList<ProductPictureDto>> ProductShortByMinPrice();
        Task<IList<ProductPictureDto>> ProductShortByMaxPrice();
        Task ProductAdd(ProductDto productDto);
        Task ProductUpdate(Product product);
        Task ProductDeleteById(int id);
        Task<Product> GetProductDetailsByProductId(int productId);
    }
}
