using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.DataAccess;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected BlogDbContext _DbContext { get; }

        public BaseRepository(BlogDbContext dbc)
        {
            _DbContext = dbc;
        }

        public async Task Add(T t)
        {
            await _DbContext.AddAsync<T>(t);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<bool> Any(object key)
        {
            var obj = await _DbContext.FindAsync<T>(key);
            return obj != null;
        }

        public async Task<T> Find(object key)
        {
            return await _DbContext.FindAsync<T>(key);
        }

        public async Task Remove(T t)
        {
            _DbContext.Remove<T>(t);
            await _DbContext.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> t)
        {
            _DbContext.RemoveRange(t);
            await _DbContext.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            _DbContext.Update<T>(t);
            await _DbContext.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<T> t)
        {
            _DbContext.UpdateRange(t);
            await _DbContext.SaveChangesAsync();
        }

        public virtual Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}