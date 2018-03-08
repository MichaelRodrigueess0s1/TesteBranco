using SQLite;
using TesteBranco.Models.Interface;
using TesteBranco.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Models.Repository
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
