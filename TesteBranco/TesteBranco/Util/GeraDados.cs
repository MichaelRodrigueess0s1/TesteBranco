using System;
using System.Collections.Generic;
using System.Text;
using TesteBranco.Models;

namespace TesteBranco.Util
{
    public class GeraDados
    {
        public static List<Profissional> GeradorProfissional()
        {
            List<Profissional> lst = new List<Profissional>();


            for(int x = 0; x < 20; x ++)
            {
                lst.Add(new Profissional
                {
                    //Comentarios = GeradorComentarios(),
                    Descricao = "dsc " + x,
                    Especialidade = "Especialidade " + x,
                    Id = x,
                    Imagem = "http://www.socialbits.com.br/wp-content/uploads/2015/03/user.png",
                    Nome = "Profissional" + x
                });
            };
            return lst;
        }

        public static List<Comentario> GeradorComentarios(Profissional profissional)
        {
            return new List<Comentario> {
                new Comentario{
                    Autor = "Michael",
                    Id = 1,
                    Data = DateTime.Now,
                    Descricao = "blablabla blablabla",
                    Profi = profissional
                },
                new Comentario{
                    Autor = "Michael",
                    Id = 1,
                    Data = DateTime.Now,
                    Descricao = "blablabla blablabla",
                    Profi = profissional
                },
                new Comentario{
                    Autor = "Michael",
                    Id = 1,
                    Data = DateTime.Now,
                    Descricao = "blablabla blablabla",
                    Profi = profissional
                },
                new Comentario{
                    Autor = "Michael",
                    Id = 1,
                    Data = DateTime.Now,
                    Descricao = "blablabla blablabla",
                    Profi = profissional
                }
            };
        }
    }
}
