using Microsoft.EntityFrameworkCore;
using MiniSepetim.Core.DataAccess.EntityFramework;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Context;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework
{
    public class PictureDal:RepositoryBase<Picture>,IPictureDal
    {
        public PictureDal(MiniSepetimContext context):base(context)
        {

        }
        public async Task<IList<Picture>> PictureWithProduct(Expression<Func<Picture,bool>> expression = null)
        {
            return await set.Include(x => x.Product).Where(expression).ToListAsync();
        }
    }
}
