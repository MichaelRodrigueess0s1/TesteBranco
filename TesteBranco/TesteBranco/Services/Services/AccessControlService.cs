using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteBranco.Infrastructure.Constants;
using TesteBranco.Infrastructure.Enums;
using TesteBranco.Infrastructure.Services;
using TesteBranco.Models;
using TesteBranco.Services.Core;
using TesteBranco.Services.Interface;

namespace TesteBranco.Services.Services
{    
    public class AccessControlService : ServiceBase, IAccessControlService
    {
        public AccessControlService() : base(_serviceName: "AccessControl", settingsUser: new SettingsUser())
        {

        }


        public Task<RespostaPadrao<String>> AceitaTermo(string matricula)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao<bool>> AtualizaLogin(string matricula, string cpf, string senhaNova, string senhaAntiga, string email, string token)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao<UsuarioDTO>> Autenticar(UsuarioDTO usuario)
        {
            return WebServiceBase<UsuarioDTO, UsuarioDTO>.RequestAsync(service: "/api/Authenticate/Authenticate", token: usuario.IdToken, triesNumber: RetriesNumber, requestType: RequestType.Get, SendObject: usuario, aut:true);           
        }

        public Task<RespostaPadrao<string>> EnviaNovaSenha(DadosUsuario du, string token)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao<string>> RecuperaSenha(string cpf, string matricula)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao<string>> VerificaToken(string tk)
        {
            throw new NotImplementedException();
        }
    }
}
