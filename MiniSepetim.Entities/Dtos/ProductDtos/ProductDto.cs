using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Path { get; set; }
        public int Count { get; set; }
        public bool State { get; set; }
    }
}
