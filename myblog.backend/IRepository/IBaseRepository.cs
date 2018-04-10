using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task Add(T t);

        Task<bool> Any(object key);

        Task<T> Find(object key);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> First(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);

        Task Remove(T t);

        Task RemoveRange(IEnumerable<T> t);

        Task Update(T t);

        Task UpdateRange(IEnumerable<T> t);
    }
}
