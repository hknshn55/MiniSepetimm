using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<IList<T>> GetList(Expression<Func<T, bool>> expression = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
