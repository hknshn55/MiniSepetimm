using AutoMapper;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using MiniSepetim.Entities.Dtos.CustomerDtos;
using MiniSepetim.Entities.Dtos.OrderDtos;
using MiniSepetim.Entities.Dtos.PictureDtos;
using MiniSepetim.Entities.Dtos.ProductDtos;
using MiniSepetim.Entities.Dtos.SellerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Insfrastructure.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto >().ReverseMap();
            CreateMap<Customer,CustomerDto >().ReverseMap();
            CreateMap<Picture, PictureDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<Category, CategoryNameDto>().ReverseMap();
        }
    }
}
