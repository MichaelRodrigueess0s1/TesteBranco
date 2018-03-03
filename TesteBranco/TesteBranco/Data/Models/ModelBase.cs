using SQLite;


namespace TesteBranco.Data.Models
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
