using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteBranco.Models;
using TesteBranco.Services.Core;

namespace TesteBranco.Services.Interface
{
    public interface IHoleriteService
    {
        Task<RespostaPadrao<List<Periodo>>> GetPeriodos(string cpf, string matricula, string idToken);
        Task<RespostaPadrao<Demonstrativo>> GetDemonstrativo(string periodo, string ano, string mes, string empresa, string fabrica, string cpf, string matricula, string token);
    }
}
