using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.CategoryDtos
{
    public class CategoryDto:IDto
    {
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } 
        public bool State { get; set; }
        
    }
}
