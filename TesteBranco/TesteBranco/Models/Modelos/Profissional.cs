using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Models
{
    [Table("Profissional")]
    public class Profissional : ModelBase
    {        
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String Especialidade { get; set; }
        public String Imagem { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
