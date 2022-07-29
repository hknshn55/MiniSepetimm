using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.ProductDtos
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public List<string> ProductPats { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string SellerName { get; set; }
        public int StockAmount { get; set; }
        public string ProductCategory { get; set; }
    }
}
