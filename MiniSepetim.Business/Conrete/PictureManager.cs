using AutoMapper;
using MiniSepetim.Business.Abstract;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.PictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class PictureManager : IPictureService
    {
        private readonly IPictureDal _pictureDal;
        private readonly IMapper _mapper;

        public PictureManager(IPictureDal pictureDal, IMapper mapper)
        {
            _pictureDal = pictureDal;
            _mapper = mapper;
        }

        public async Task<Picture> GetPictureById(int id)
        {
            return await _pictureDal.Get(x=>x.Id == id);
        }

        public async Task<Picture> GetPictureByProductId(int productId)
        {
            return await _pictureDal.Get(x=>x.ProductId == productId);
        }

        public async Task PictureAdd(PictureDto pictureDto)
        {
            Picture picture = _mapper.Map<Picture>(pictureDto);
            await _pictureDal.Add(picture);
        }

        public async Task PictureDeleteById(int pictureId)
        {
            Picture picture= await GetPictureById(pictureId);
            if (picture!=null)
            {
                await _pictureDal.Delete(picture);
            }
        }

        public async Task<IList<Picture>> PictureList()
        {
            return await _pictureDal.GetList();
        }

        public async Task<IList<Picture>> PictureListByProductId(int productId)
        {
            return await _pictureDal.GetList(x=>x.ProductId == productId);
        }

        public async Task PictureUpdate(Picture picture)
        {
            await _pictureDal.Update(picture);
        }
        public async Task<IList<Picture>> PictureWithProduct(int productId)
        {
            return await _pictureDal.PictureWithProduct(x=>x.ProductId == productId);
        }
    }
}
