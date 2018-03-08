using SQLite;

namespace TesteBranco.Models.Interface
{
    public interface IConnection
    {
        SQLiteAsyncConnection GetConection(string filename = null);
    }
}
