using SQLite;

namespace SQLiteDataBase.Models
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
