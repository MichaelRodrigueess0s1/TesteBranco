using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.DataBase
{
    public interface IDataBase
    {
        SQLiteConnection GetConnection();
    }
}
