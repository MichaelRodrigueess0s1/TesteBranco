using SQLite;
using TesteBranco.Models.Interface;
using TesteBranco.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TesteBranco.Models.UoW
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

        private RepositoryProfissional _repositoryProfissional;

        public RepositoryProfissional RepositoryProfissional
        {
            get
            {
                if (_repositoryProfissional == null)
                {
                    _repositoryProfissional = new RepositoryProfissional(Connection);
                }
                return _repositoryProfissional;
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
