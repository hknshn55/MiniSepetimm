using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Entities.Dtos.PictureDtos
{
    public class PictureDto:IDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
