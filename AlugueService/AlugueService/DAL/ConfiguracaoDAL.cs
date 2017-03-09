using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlugueService.DTO;
using AlugueService.Models;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace AlugueService.DAL
{
    public class ConfiguracaoDAL
    {
        public ConfiguracaoDTO cadastrarConfiguracao(Configuracao configuracao)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(configuracao);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Configuracao/Cadastrar"), "POST", dataString);

                Debug.WriteLine(HtmlResult);

                //ConfiguracaoDTO confDTO = new JavaScriptSerializer().Deserialize<ConfiguracaoDTO>(HtmlResult);

                ConfiguracaoDTO confDTO = JsonConvert.DeserializeObject<ConfiguracaoDTO>(HtmlResult);

                return confDTO;
            }
        }

        internal ConfiguracaoDTO pesquisarUltimo()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.DownloadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Configuracao/PesquisarUltimo"));
                Debug.WriteLine(HtmlResult);
                ConfiguracaoDTO confDTO = JsonConvert.DeserializeObject<ConfiguracaoDTO>(HtmlResult);
                return confDTO;
            }
        }
    }
}