using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Models
{
    public class Comentario
    {        
        public int Id { get; set; }
        public Profissional Profi { get; set; }
        public String Autor { get; set; }
        public DateTimeOffset Data { get; set; }
        public String Descricao { get; set; }

    }
}
