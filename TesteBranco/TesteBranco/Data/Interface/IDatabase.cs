using SQLite;


namespace TesteBranco.Data.Interface
{
    public interface IDatabase
    {
        SQLiteAsyncConnection DatabaseConnection { get; }
    }
}
