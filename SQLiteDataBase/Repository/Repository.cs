using SQLite;
using SQLiteDataBase.Interface;
using SQLiteDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SQLiteDataBase.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase, new()
    {

        private SQLiteAsyncConnection db;

        public Repository(SQLiteAsyncConnection db)
        {
            this.db = db;
        }

        public AsyncTableQuery<T> AsyncTableQuery() => db.Table<T>();

        public async Task<int> Delete(T entity) =>  await db.DeleteAsync(entity);

        public async Task<List<T>> Get() => await db.Table<T>().ToListAsync();

        public async Task<T> Get(int id) => await db.FindAsync<T>(id);

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }
            return await query.ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
          int r =   await db.InsertAsync(entity);

            if(r == 1)
            {
                return entity;
            }else
            {
                throw new Exception("Falha ao inserir entidade!");
            }
        }

        public async Task<int> Update(T entity) => await db.UpdateAsync(entity);
        
    }
}
