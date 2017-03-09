using AlugueService.DTO;
using AlugueService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace AlugueService.DAL
{
    public class OperadorDAL
    {
        public OperadorDTO cadastrarOperador(Operador operador)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(operador);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Operador/Cadastrar"), "POST", dataString);

                Debug.WriteLine(HtmlResult);

                OperadorDTO operadorDTO = JsonConvert.DeserializeObject<OperadorDTO>(HtmlResult);
                return operadorDTO;
            }


        }

        public OperadorDTO pesquisarOperador()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.DownloadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Operador/Pesquisar"));
                Debug.WriteLine(HtmlResult);
                OperadorDTO operadorDTO = JsonConvert.DeserializeObject<OperadorDTO>(HtmlResult);
                return operadorDTO;
            }
        }

        public OperadorDTO autenticarOperador(Operador pOperador)
        {
            var tDto = pesquisarOperador();
            if (tDto.ok)
            {
                var tLista = tDto.lista.Where(operador => operador.login.Equals(pOperador.login));
                if (tLista != null && tLista.Count() > 0)
                {
                    var tOperador = tLista.First();
                    if (tOperador.senha == pOperador.senha)
                    {
                        return new OperadorDTO(true, "Usuário autênticado com sucesso.", tOperador);
                    }
                    else
                    {
                        return new OperadorDTO(false, "Senha incorreta.");
                    }
                }
                else
                {
                    return new OperadorDTO(false, "Login e/ou senha incorreta.");
                }
            }else
            {
                return new OperadorDTO(false, "Não foi possivel conectar ao web service");
            }

        }

        public OperadorDTO atualizarOperador(Operador operador)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(operador);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                Debug.WriteLine(dataString);
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Operador/Atualizar"), "PUT", dataString);
                Debug.WriteLine(HtmlResult);
                OperadorDTO operadorDTO = JsonConvert.DeserializeObject<OperadorDTO>(HtmlResult);
                return operadorDTO;
            }
        }
    }
}