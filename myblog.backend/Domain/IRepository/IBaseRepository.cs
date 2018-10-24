using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyBlog.Domain.IRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T> InsertAsync(T t);

        Task<bool> Any(object key);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> All();

        IDbContextTransaction BeginTransaction();

        Task<T> FindAsync(object key);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        void Remove(T t);

        void RemoveRange(IEnumerable<T> t);

        Task<T> UpdateAsync(T t);

        Task UpdateRangeAsync(IEnumerable<T> t);

        IQueryable<T> Except(IQueryable<T> second);

        IQueryable<T> Union(IQueryable<T> second);

        IQueryable<T> Intersect(IQueryable<T> second);
    }
}
