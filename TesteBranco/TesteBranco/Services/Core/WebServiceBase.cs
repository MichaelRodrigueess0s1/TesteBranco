using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteBranco.Infrastructure.Constants;
using TesteBranco.Infrastructure.Enums;
using TesteBranco.Infrastructure.Json;
using TesteBranco.Models;
using TesteBranco.Services.Core;

namespace TesteBranco.Services.Core
{
    public static class WebServiceBase<O, I>
         where O : class
         where I : class
    {
        public static async Task<RespostaPadrao<O>> RequestAsync
            (
                string service, 
                string token, 
                int triesNumber = 0, 
                RequestType requestType = RequestType.Get, 
                I SendObject = null,
                bool aut = false
            )
        {
            RespostaPadrao<O> resposta = new RespostaPadrao<O>();
            var url = $"{BaseAppConstants.BaseURL}{service}";
            HttpResponseMessage response = new HttpResponseMessage();

            for (int i = 0; i <= triesNumber; i++)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add(BaseAppConstants.SVC, BaseAppConstants.TipoServico);
                        client.DefaultRequestHeaders.Add(BaseAppConstants.PRF, BaseAppConstants.Perfil);
                     
                        if(aut)
                        {
                            UsuarioDTO usuario = SendObject as UsuarioDTO;
                            var basis = string.Format("{0}:{1}", usuario.Login, usuario.Senha);
                            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(basis));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                        }
                            


                        if (!string.IsNullOrEmpty(token))
                            client.DefaultRequestHeaders.Add(BaseAppConstants.Token, token);

                        var content = JsonHelper<I>.ObjectToJson(SendObject);

                        switch (requestType)
                        {
                            case RequestType.Get:
                                response = await client.GetAsync(url);
                                break;
                            case RequestType.Post:
                                response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                                break;
                            case RequestType.Put:
                                response = await client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                                break;
                            case RequestType.Delete:
                                response = await client.DeleteAsync(url);
                                break;
                            default:
                                break;
                        }

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();

                            resposta.Content = JsonHelper<O>.JsonToObject(responseString);
                            resposta.IsSuccess = true;

                            triesNumber = i++;
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                            {
                                if (i == triesNumber)
                                {
                                    resposta.Message = "Tempo limite atingido";
                                    resposta.IsSuccess = false;
                                }
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resposta.Message = "Serviço não encontrado";
                                resposta.IsSuccess = false;
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                            {
                                if (i == triesNumber)
                                {
                                    resposta.Message = "Serviço indisponível no momento";
                                    resposta.IsSuccess = false;
                                }
                            }
                            else
                            {
                                resposta.Message = "Falha no acesso!";
                                resposta.IsSuccess = false;
                            }
                        }
                    }
                }
                catch (JsonException jsonException)
                {
                    resposta.Message = $"JsonException: {jsonException.Message}";
                    resposta.IsSuccess = false;
                }
                catch (HttpRequestException httpRequestException)
                {
                    resposta.Message = $"Exception: {httpRequestException.Message}";
                    resposta.IsSuccess = false;
                }
                catch (Exception exception)
                {
                    resposta.Message = $"Exception: {exception.Message}";
                    resposta.IsSuccess = false;
                }
            }
            return resposta;
        }

    }
}

