
using MiniSepetim.Core.DataAccess.EntityFramework;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.DataAccess.Concrete.EntityFramework.Context;
using MiniSepetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.DataAccess.Concrete.EntityFramework
{
    public class CategoryDal:RepositoryBase<Category>,ICategoryDal
    {
        public CategoryDal(MiniSepetimContext context):base(context)
        {
                
        }
        
    }
}
