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
        void Add(T t);

        bool Any(object key);

        bool Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> All();

        IDbContextTransaction BeginTransaction();

        T Find(object key);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        T First(Expression<Func<T, bool>> predicate);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        void Remove(T t);

        void RemoveRange(IEnumerable<T> t);

        void Update(T t);

        void UpdateRange(IEnumerable<T> t);

        IQueryable<T> Except(IQueryable<T> second);

        IQueryable<T> Union(IQueryable<T> second);

        IQueryable<T> Intersect(IQueryable<T> second);
    }
}
