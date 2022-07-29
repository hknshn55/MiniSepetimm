
using Microsoft.EntityFrameworkCore;
using MiniSepetim.Core.DataAccess.EntityFramework;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Context;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework
{
    public class ProductDal:RepositoryBase<Product>,IProductDal
    {
        public ProductDal(MiniSepetimContext context):base(context)
        {

        }

        public async Task<ProductDetailDto> ProductWithSellerAndCategory(Product product)
        {
            return await set.Include(x => x.Seller).Include(x => x.Category).Include(x => x.Pictures).Where(x => x.Id == product.Id).
                Select(x => new ProductDetailDto
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    ProductCategory = x.Category.Name,
                    SellerName = x.Seller.Name
                 ,ProductDescription=x.Description,
                    ProductPrice = x.Price,
                    ProductPats = x.Pictures.Select(x=>x.Name).ToList(),
                    StockAmount=x.UnitInStock
                }).FirstOrDefaultAsync();
            
        }
        public async Task<IList<ProductPictureDto>> ProductPictureList()
        {
            return await set.Include(x => x.Seller).ThenInclude(x=>x.AppIdentityUser).Include(x => x.Category).Include(x => x.Pictures).
                Select(x => new ProductPictureDto
                {
                    ProductId = x.Id,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    ProductName = x.Name,
                    SellerName = x.Seller.Name,
                    SellerUserName=x.Seller.AppIdentityUser.UserName,
                    State = x.State,
                    Paths = x.Pictures.Select(x=>x.Name).SingleOrDefault(),
                    Count=x.UnitInStock
                }).ToListAsync();
        }
        public async Task<IList<Product>> ProductWithCategory()
        {
            return await set.Include(x => x.Category).ToListAsync();
                
        }

        public async Task<Product> ProductDetails(int productId)
        {
            return await set.Include(x => x.Pictures).Include(x => x.Seller).Include(x => x.Category).SingleOrDefaultAsync(x=>x.Id==productId);
        }
    }
}
