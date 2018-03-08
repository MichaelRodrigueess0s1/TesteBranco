using SQLite;
using SQLiteDataBase.Interface;
using SQLiteDataBase.Models;
using SQLiteDataBase.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDataBase.UoW
{
    public class UnitOfWork : IDisposable
    {
        protected readonly SQLiteAsyncConnection Connection;

        private RepositoryUsuario _repositoryUsuario;

        public RepositoryUsuario RepositoryUsuario
        {
            get
            {
                if (_repositoryUsuario == null)
                {
                    _repositoryUsuario = new RepositoryUsuario(Connection);
                }
                return _repositoryUsuario;
            }
        }

        
        public UnitOfWork()
        {
            Connection = DependencyService.Get<IConnection>().GetConection();
            Connection.CreateTableAsync<Usuario>();
        }

        public void Dispose()
        {
            
        }
    }
}
