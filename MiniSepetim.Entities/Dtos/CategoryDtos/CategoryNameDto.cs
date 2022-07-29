using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.CategoryDtos
{
    public class CategoryNameDto:IDto
    {
        public int CategoryId { get; set; } = 1;
        public string CategoryName { get; set; } = "hakan";
    }
}
