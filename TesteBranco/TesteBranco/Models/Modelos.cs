using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TesteBranco.Models
{

    public class DadosUsuario
    {
        public string P1 { get; set; } // Matricula
        public string P2 { get; set; } // cpf
        public string P3 { get; set; } // senha antiga
        public string P4 { get; set; } // senha nova
        public string P5 { get; set; } // E-mail
    }

    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Doc
        {
            get { return Matricula + "-" + Cpf; }
            set
            {
                Cpf = value.Split('-')[1];
                Matricula = value.Split('-')[0];
            }
        }
        public string Matricula { get; private set; }
        public string Cpf { get; private set; }
        public string Status { get; set; }
        public string Perfil { get; set; }
        public string Servico { get; set; }
        public string IdToken { get; set; }
        public bool DataTermo { get; set; }
        public bool AceitouTermo { get; internal set; }
    }

    public class Notificacao
    {
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Texo { get; set; }
        public bool Block { get; set; }

    }


    public class Colaborador
    {
        public string Nome
        {
            get;
            set;
        }

        public string Cargo
        {
            get;
            set;
        }

        public string Empresa
        {
            get;
            set;
        }

        public string Unidade
        {
            get;
            set;
        }

        public string Cpf
        {
            get;
            set;
        }

        public string DataAdmissao
        {
            get;
            set;
        }

        public string DataReferencia
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Matricula
        {
            get;
            set;
        }
    }

    public class Holerite
    {
        public List<Lancamento> Lancamentos
        {
            get;
            set;
        }

        public Colaborador Empregado
        {
            get;
            set;
        }

        public string Mensagem
        {
            get;
            set;
        }
    }

    public class Lancamento
    {
        public string Periodo
        {
            get;
            set;
        }

        public string DataPagto
        {
            get;
            set;
        }

        public string TipoEvento
        {
            get;
            set;
        }

        public string CodEvento
        {
            get;
            set;
        }

        public string DscEvento
        {
            get;
            set;
        }

        public string Referencia
        {
            get;
            set;
        }

        [Display(Name = "Valor"), DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public string Valor
        {
            get;
            set;
        }

        [Display(Name = "Cnpj"), DisplayFormat(DataFormatString = "{0:###.###.###-##}", ApplyFormatInEditMode = true)]
        public string Cnpj
        {
            get;
            set;
        }
    }


    public class Periodo
    {
        public string Tipo
        {
            get;
            set;
        }

        public string Descricao
        {
            get;
            set;
        }
    }

    public class Demonstrativo
    {
        public Colaborador colaborador
        {
            get;
            set;
        }

        public List<Lancamento> Lancamentos
        {
            get;
            set;
        }
    }

}
