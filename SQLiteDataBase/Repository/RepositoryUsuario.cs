using SQLite;
using SQLiteDataBase.Interface;
using SQLiteDataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDataBase.Repository
{
    public class RepositoryUsuario : Repository<Usuario>, IRepository<Usuario>
    {
        public RepositoryUsuario(SQLiteAsyncConnection db) : base(db)
        {
        }

        public async System.Threading.Tasks.Task InsereUsuarioAsync(Usuario usuario)
        {
            await Insert(usuario);
        }


    }
}
