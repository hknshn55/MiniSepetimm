using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.PictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface IPictureService
    {
        Task<IList<Picture>> PictureWithProduct(int productId);
        Task<Picture> GetPictureById(int id);
        Task<IList<Picture>> PictureListByProductId(int productId);
        Task<IList<Picture>> PictureList();
        Task PictureAdd(PictureDto pictureDto);
        Task PictureUpdate(Picture picture);
        Task PictureDeleteById(int pictureId);
    }
}
