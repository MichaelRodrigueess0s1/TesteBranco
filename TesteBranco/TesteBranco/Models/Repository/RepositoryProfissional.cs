using SQLite;
using TesteBranco.Models.Interface;
using TesteBranco.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Models.Repository
{
    public class RepositoryProfissional : Repository<Profissional>, IRepository<Profissional>
    {
        public RepositoryProfissional(SQLiteAsyncConnection db) : base(db)
        {
        }
    }
}
