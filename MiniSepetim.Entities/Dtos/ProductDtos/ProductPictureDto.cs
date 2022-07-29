using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.ProductDtos
{
    public class ProductPictureDto
    {
        public int ProductId { get; set; }
        public string Paths { get; set; }
        public string CategoryName { get; set; }
        public string SellerName { get; set; }
        public string SellerUserName { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool State { get; set; }
    }
}
