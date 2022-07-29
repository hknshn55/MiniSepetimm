using MiniSepetim.Core.DataAccess;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Abstract
{
    public interface IPictureDal:IRepository<Picture>
    {
        Task<IList<Picture>> PictureWithProduct(Expression<Func<Picture, bool>> expression = null);
    }
}
