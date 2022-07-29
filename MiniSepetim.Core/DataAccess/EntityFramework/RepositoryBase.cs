using Microsoft.EntityFrameworkCore;
using MiniSepetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Core.DataAccess.EntityFramework
{
    public class RepositoryBase<T> :IRepository<T> where T : class, IEntity, new()
    {
        public DbContext _db;
        public DbSet<T> set;
        public RepositoryBase(DbContext db)
        {
            _db = db;
            set = _db.Set<T>();
        }
        public async Task Add(T entity)
        {
            set.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            set.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await set.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetList(System.Linq.Expressions.Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? await set.ToListAsync()
                : await set.Where(expression).ToListAsync();
        }

        public async Task Update(T entity)
        {
            set.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
