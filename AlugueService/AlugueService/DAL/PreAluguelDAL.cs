using AlugueService.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace AlugueService.DAL
{
    public class PreAluguelDAL
    {
        public PreAluguelDTO pesquisarPreAluguel()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.DownloadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/PreAluguel/Pesquisar"));
                Debug.WriteLine(HtmlResult);
                PreAluguelDTO preAluguelDTO = JsonConvert.DeserializeObject<PreAluguelDTO>(HtmlResult);
                return preAluguelDTO;
            }
        }

    }
}