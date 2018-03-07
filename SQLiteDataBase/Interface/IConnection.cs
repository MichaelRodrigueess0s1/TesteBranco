using SQLite;

namespace SQLiteDataBase.Interface
{
    public interface IConnection
    {
        SQLiteAsyncConnection GetConection(string filename);
    }
}
