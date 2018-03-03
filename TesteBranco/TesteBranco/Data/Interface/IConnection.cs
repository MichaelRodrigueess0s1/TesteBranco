using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Data.Interface
{
    public interface IConnection
    {
        SQLiteAsyncConnection GetConection(string filename);
    }
}
