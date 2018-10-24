using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBlog.Domain.IRepository;

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

        public async Task<T> InsertAsync(T t)
        {
            var entityEntry = await _DbContext.AddAsync<T>(t);
            return entityEntry.Entity;
        }

        public Task<bool> AnyAsync(object key)
        {
            return _DbContext.Set<T>().AnyAsync();
        }

        public Task<T> FindAsync(object key)
        {
            return _DbContext.FindAsync<T>(key);
        }

        public void Remove(T t)
        {
            _DbContext.Remove(t);
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            _DbContext.RemoveRange(t);
        }

        public Task<T> UpdateAsync(T t)
        {
            AttachIfNot(entity);
            _DbContext.Entry(t).State = EntityState.Modified;
            return Task.FromResult(t);
        }

        public void UpdateRange(IEnumerable<T> t)
        {
            _DbContext.UpdateRange(t);
            _DbContext.SaveChanges();
        }

        public IQueryable<T> All() => _DbContext.Set<T>();


        public T FirstOrDefault(Expression<Func<T, bool>> predicate) => _DbContext.Set<T>().FirstOrDefault(predicate);

        public T First(Expression<Func<T, bool>> predicate) => _DbContext.Set<T>().First(predicate);

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _DbContext.Set<T>().Where(predicate);

        public bool Any(Expression<Func<T, bool>> predicate) => _DbContext.Set<T>().Any(predicate);

        public IQueryable<T> Except(IQueryable<T> second) => _DbContext.Set<T>().Except(second);

        public IQueryable<T> Union(IQueryable<T> second) => _DbContext.Set<T>().Union(second);

        public IQueryable<T> Intersect(IQueryable<T> second) => _DbContext.Set<T>().Intersect(second);

        public IDbContextTransaction BeginTransaction()
        {
            return _DbContext.Database.BeginTransaction();
        }
    }
}
