using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace TesteBranco.Models.Interface
{
    public interface IRepository<T> where T: class, new()
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        AsyncTableQuery<T> AsyncTableQuery();
        Task<T> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
