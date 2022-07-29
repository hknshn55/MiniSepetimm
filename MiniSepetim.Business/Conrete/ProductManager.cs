using AutoMapper;
using FluentValidation.Results;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Business.ValidationRules.FluentValidation;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.PictureDtos;
using MiniSepetim.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        ProductValidator rules = new ProductValidator();
        public ValidationResult Validator(Product product)
        {
            return rules.Validate(product);
        }


        public ProductManager(IProductDal productDal, IMapper mapper, IPictureService pictureService)
        {
            _productDal = productDal;
            _mapper = mapper;
            _pictureService = pictureService;
        }





        public async Task<IList<Product>> ProductWithCategory()
        {
          return   await _productDal.ProductWithCategory();
        }






        public async Task<ProductDetailDto> ProductDetail(int id)
        {
           var product = await GetProductById(id);
           return await _productDal.ProductWithSellerAndCategory(product);
        }
        public async Task<IList<Product>> GetListProduct()
        {
            return await _productDal.GetList();
        }

        public async Task<IList<Product>> GetListProductByName(string productName)
        {
            return await _productDal.GetList(x=>x.Name == productName);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productDal.Get(x=>x.Id == id);
        }

        public async Task ProductAdd(ProductDto productDto)
        {
            //2 tabloya birden ekleme işlemi gerçekten mantıklımı düşünülecek!
            //SOLID prensiplerinde S harfinin ezilip ezilmediği düşünülecek!
            Product product = _mapper.Map<Product>(productDto);
            product.UnitInStock = productDto.Count;
            var result = Validator(product);
            if (result.IsValid)
            {
                await _productDal.Add(product);
                await _pictureService.PictureAdd(new PictureDto { Name = productDto.Path, ProductId = product.Id });
            }
        }

        public async Task ProductDeleteById(int id)
        {
            Product product = await GetProductById(id);
            await _productDal.Delete(product);
        }

        public async Task<IList<ProductPictureDto>> ProductShortByMaxPrice()
        {
            return (await _productDal.ProductPictureList()).OrderByDescending(x=>x.Price).ToList();
        }

        public async Task<IList<ProductPictureDto>> ProductShortByMinPrice()
        {
            return (await _productDal.ProductPictureList()).OrderBy(x => x.Price).ToList();
        }

        public async Task ProductUpdate(Product product)
        {
            var result = Validator(product);
            if (result.IsValid)
            {
                await _productDal.Update(product);
            }
            
        }

        public async Task<IList<ProductPictureDto>> ProductPictureList()
        {
            return await _productDal.ProductPictureList();
        }


        public async Task<Product> GetProductDetailsByProductId(int productId)
        {
            return await _productDal.ProductDetails(productId);
        }
    }
}
