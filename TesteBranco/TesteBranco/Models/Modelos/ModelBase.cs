using SQLite;

namespace TesteBranco.Models
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
