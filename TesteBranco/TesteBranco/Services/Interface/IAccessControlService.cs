using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteBranco.Models;
using TesteBranco.Services.Core;

namespace TesteBranco.Services.Interface
{
    public interface IAccessControlService
    {
        Task<RespostaPadrao<UsuarioDTO>> Autenticar(UsuarioDTO usuario);
        Task<RespostaPadrao<bool>> AtualizaLogin(string matricula, string cpf, string senhaNova, string senhaAntiga, string email, string token);
        Task<RespostaPadrao<string>> RecuperaSenha(string cpf, string matricula);
        Task<RespostaPadrao<string>> EnviaNovaSenha(DadosUsuario du, string token);
        Task<RespostaPadrao<string>> VerificaToken(string tk);
        Task<RespostaPadrao<string>> AceitaTermo(string matricula);
    }
}
