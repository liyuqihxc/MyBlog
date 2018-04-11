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

        public void Add(T t)
        {
            _DbContext.Add<T>(t);
            _DbContext.SaveChanges();
        }

        public bool Any(object key)
        {
            var obj = _DbContext.Find<T>(key);
            return obj != null;
        }

        public T Find(object key)
        {
            return _DbContext.Find<T>(key);
        }

        public void Remove(T t)
        {
            _DbContext.Remove<T>(t);
            _DbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            _DbContext.RemoveRange(t);
            _DbContext.SaveChanges();
        }

        public void Update(T t)
        {
            _DbContext.Update<T>(t);
            _DbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> t)
        {
            _DbContext.UpdateRange(t);
            _DbContext.SaveChanges();
        }

        public virtual IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
