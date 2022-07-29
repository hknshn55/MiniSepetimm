using Microsoft.AspNetCore.Http;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSepetim.UI.Models.ViewModels
{
    public class AddProductVM
    {
        public List<CategoryNameDto> Categories { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Path { get; set; }
        public int Count { get; set; }
        public bool State { get; set; }
    }
}
