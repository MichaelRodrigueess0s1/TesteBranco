
using System.Collections.Generic;
using SQLite;

namespace TesteBranco.Models
{ 
    [Table("Usuario")]
    public class Usuario : ModelBase
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Doc { get; set; }
        public string Matricula { get;  set; }
        public string Cpf { get;  set; }
        public string Status { get; set; }
        public string Perfil { get; set; }
        public string Servico { get; set; }
        public string IdToken { get; set; }
        public bool DataTermo { get; set; }
        public bool AceitouTermo { get;  set; }
    }  
}
