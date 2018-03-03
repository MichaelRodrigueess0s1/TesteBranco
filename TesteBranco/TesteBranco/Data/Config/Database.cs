
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBranco.Data.Interface;
using TesteBranco.Infrastructure.Constants;
using Xamarin.Forms;

namespace TesteBranco.Data.Config
{
    public class Database : IDatabase
    {
        private SQLiteAsyncConnection _database;
        public SQLiteAsyncConnection DatabaseConnection
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }

        public Database()
        {
            DatabaseConnection = DependencyService.Get<IConnection>().GetConection(BaseAppConstants.DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            //DatabaseConnection.CreateTableAsync<"ClasseName">().Wait();
        }
    }
}
