using AlugueService.DTO;
using AlugueService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace AlugueService.DAL
{
    public class ClienteDAL
    {
        public ClienteDTO cadastrarCliente (Cliente cliente)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(cliente);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Cliente/Cadastrar"), "POST", dataString);

                Debug.WriteLine(HtmlResult);

                //ClienteDTO clienteDTO = new JavaScriptSerializer().Deserialize<ClienteDTO>(HtmlResult);

                ClienteDTO clienteDTO = JsonConvert.DeserializeObject<ClienteDTO>(HtmlResult);

                return clienteDTO;
            }
            

        }

        public ClienteDTO pesquisarCliente()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.DownloadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Cliente/Pesquisar"));
                Debug.WriteLine(HtmlResult);
                ClienteDTO clienteDTO = JsonConvert.DeserializeObject<ClienteDTO>(HtmlResult);
                return clienteDTO;
            }
        }

        public ClienteDTO atualizarCliente(Cliente cliente)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(cliente);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                Debug.WriteLine(dataString);
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Cliente/Atualizar"), "PUT", dataString);
                Debug.WriteLine(HtmlResult);
                ClienteDTO clienteDTO = JsonConvert.DeserializeObject<ClienteDTO>(HtmlResult);
                return clienteDTO;
            }
        }

    }
}