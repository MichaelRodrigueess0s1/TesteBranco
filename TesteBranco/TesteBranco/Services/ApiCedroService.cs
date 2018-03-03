using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteBranco.Models;

namespace TesteBranco.Services
{
    public class ApiCedroService
    {
        //const string URLBASE = "http://cedronet2:89/{0}";
        const string URLBASE = "http://api.cedro.com.br/{0}";
        //const string URLBASE = "http://localhost:1586/{0}";
        HttpClient _httpClient;
        public async Task<UsuarioDTO> AutenticaLogin(string login, string senha)
        {
            string url = "api/Authenticate/Authenticate";
            try
            {
                using (_httpClient = new HttpClient())
                {
                    var uri = string.Format(URLBASE, url);
                    var basis = string.Format("{0}:{1}", login, senha);
                    var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(basis));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                    _httpClient.DefaultRequestHeaders.Add("Svc", "INMC");
                    _httpClient.DefaultRequestHeaders.Add("Prf", "0");
                    var result = await _httpClient.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var cola = JsonConvert.DeserializeObject<UsuarioDTO>(content);
                       // cola.AceitouTermo = await VerificaTermo(cola.Matricula);
                        return cola;
                    }
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                         throw new Exception("Acesso não autorizado!");
                    }
                    else
                    {
                        throw new Exception("Sua requisição não trouxe resultados!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> VerificaTermo(string matricula)
        {
            string url = "api/anonimo/VerificaTermo/{0}";
            try
            {
                using (_httpClient = new HttpClient())
                {
                    var uri = string.Format(URLBASE, url);
                    uri = string.Format(uri, matricula);
                    var result = await _httpClient.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        bool resp = JsonConvert.DeserializeObject<bool>(content);
                        _httpClient.Dispose();
                        return resp;
                    }
                    else
                    {
                        throw new Exception("O Servidor não conseguiu atender a solicitação!");
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message.Equals("O Servidor não conseguiu atender a solicitação"))
                    throw e;

                else
                    throw new Exception("Erro interno");
            }
        }


        public List<Periodo> GetPeriodos(string cpf, string matricula, string idToken)
        {
            string url = "api/MinhaCedro/GetPeriodos?cpf={0}&matricula={1}";
            try
            {
                using (_httpClient = new HttpClient())
                {
                    List<Periodo> lst = null;
                    _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.Add("Svc", "INMC");
                    _httpClient.DefaultRequestHeaders.Add("Token", idToken);
                    _httpClient.DefaultRequestHeaders.Add("Prf", "0");
                    string ur2 = string.Format(url, cpf, matricula);
                    var uri = string.Format(URLBASE, ur2);
                    var task = _httpClient.GetAsync(uri)
                      .ContinueWith((taskwithresponse) =>
                      {
                          var response = taskwithresponse.Result;
                          var jsonString = response.Content.ReadAsStringAsync();
                          jsonString.Wait();
                          lst = JsonConvert.DeserializeObject<List<Periodo>>(jsonString.Result);
                      });
                    task.Wait();
                    _httpClient.Dispose();
                    return lst;
                }
            }
            catch (Exception)
            {
                _httpClient.Dispose();
                throw;
            }
        }

        public async Task<Demonstrativo> GetDemonstrativo(string periodo, string ano, string mes, string empresa, string fabrica, string cpf, string matricula, string token)
        {
            try
            {
                using (_httpClient = new HttpClient())
                {
                    string url = "api/MinhaCedro/GetDemonstrativo?periodo={0}&ano={1}&mes={2}&matricula={3}&numCpf={4}&empresa={5}&fabrica={6}";
                    string ur2 = string.Format(url, periodo, ano, mes, matricula, cpf, empresa, fabrica);
                    var uri = string.Format(URLBASE, ur2);
                    _httpClient.DefaultRequestHeaders.Add("Svc", "INMC");
                    _httpClient.DefaultRequestHeaders.Add("Token", token);
                    _httpClient.DefaultRequestHeaders.Add("Prf", "0");
                    var result = await _httpClient.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var demonstrativo = JsonConvert.DeserializeObject<Demonstrativo>(content);
                        _httpClient.Dispose();
                        return demonstrativo;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AtualizaLogin(string matricula, string cpf, string senhaNova, string senhaAntiga, string email, string token)
        {
            //CedroData.Criptografia _crip = new CedroData.Criptografia();
            matricula = Util.Criptografia.Cript(matricula);
            cpf = Util.Criptografia.Cript(cpf);
            senhaAntiga = Util.Criptografia.Cript(senhaAntiga);
            senhaNova = Util.Criptografia.Cript(senhaNova);
            email = Util.Criptografia.Cript(email);
            DadosUsuario du = new DadosUsuario
            {
                P1 = matricula, //CPF
                P2 = cpf,
                P3 = senhaNova,
                P4 = senhaAntiga,
                P5 = email
            };

            //p1 = matricula, p2 = cpf, p3 = senha nova, p4 = senha antiga
            string url = "api/MinhaCedro/AlteraDados";
            try
            {
                using (_httpClient = new HttpClient())
                {
                    var uri = string.Format(URLBASE, url);
                    _httpClient.DefaultRequestHeaders.Add("Svc", "INMC");
                    _httpClient.DefaultRequestHeaders.Add("Token", token);
                    _httpClient.DefaultRequestHeaders.Add("Prf", "0");

                    string json = JsonConvert.SerializeObject(du);
                    HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await _httpClient.PostAsync(uri, contentPost);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<bool>(content);
                        return resp;
                    }
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                _httpClient.Dispose();
                throw;
            }
        }

        public async Task<string> RecuperaSenha(string cpf, string matricula)
        {
            try
            {
                using (_httpClient = new HttpClient())
                {
                    string url = "api/Anonimo/RecuperaSenha?cpf={0}&svc=INMC";
                    string ur2 = string.Format(url, cpf);
                    var uri = string.Format(URLBASE, ur2);
                    _httpClient.DefaultRequestHeaders.Add("Svc", "INMC");
                    _httpClient.DefaultRequestHeaders.Add("Matricula", matricula);
                    var result = await _httpClient.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        return resp;
                    }
                    else
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        throw new Exception(resp);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> EnviaNovaSenha(DadosUsuario du, string token)
        {
            
            du.P1 = Util.Criptografia.Cript(du.P1);
            du.P2 = Util.Criptografia.Cript(du.P2);
            du.P3 = Util.Criptografia.Cript(du.P3);
            du.P4 = Util.Criptografia.Cript("gambi");
            du.P5 = Util.Criptografia.Cript(du.P5);

            //p1 = matricula, p2 = cpf, p3 = senha nova, p4 = senha antiga
            try
            {
                string url = "api/Anonimo/TrocaSenhaMinhaCedro?token={0}";
                using (_httpClient = new HttpClient())
                {
                    var uri = string.Format(URLBASE, url);
                    uri = string.Format(uri, token);

                    string json = JsonConvert.SerializeObject(du);
                    HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await _httpClient.PostAsync(uri, contentPost);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                    }
                    else
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        throw new Exception(resp);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public async Task<string> VerificaToken(string tk)
        {
            try
            {
                using (_httpClient = new HttpClient())
                {
                    string url = "api/Anonimo/VerificaTokenSenhaRecuperaSenha?token={0}&svc=INMC";
                    string ur2 = string.Format(url, tk);
                    var uri = string.Format(URLBASE, ur2);
                    var result = await _httpClient.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        return resp;
                    }
                    else
                    {
                        var content = await result.Content.ReadAsStringAsync();
                        var resp = JsonConvert.DeserializeObject<string>(content);
                        throw new Exception(resp);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao enviar requisição!");
            }
        }

        internal async Task<string> AceitaTermo(string matricula)
        {
            using (_httpClient = new HttpClient())
            {
                string url = "api/Anonimo/GravaAceiteAcordo?matricula={0}";
                string ur2 = string.Format(url, matricula);
                var uri = string.Format(URLBASE, ur2);
                var result = await _httpClient.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var resp = JsonConvert.DeserializeObject<string>(content);
                    return resp;
                }
                else
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var resp = JsonConvert.DeserializeObject<string>(content);
                    throw new Exception(resp);
                }
            }
        }
    }


}
