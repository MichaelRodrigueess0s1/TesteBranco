using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Models
{
    [Table("Comentario")]
    public class Comentario : ModelBase
    {   
        public Profissional Profi { get; set; }
        public String Autor { get; set; }
        public DateTimeOffset Data { get; set; }
        public String Descricao { get; set; }
    }
}
