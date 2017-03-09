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
    public class ProdutoDAL
    {
        public ProdutoDTO cadastrarProduto(Produto produto)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(produto);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                Debug.WriteLine(dataString);
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Produto/Cadastrar"), "POST", dataString);
                Debug.WriteLine(HtmlResult);
                ProdutoDTO produtoDTO = JsonConvert.DeserializeObject<ProdutoDTO>(HtmlResult);
                return produtoDTO;
            }
        }

        public ProdutoDTO pesquisarProduto()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                var HtmlResult = client.DownloadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Produto/Pesquisar"));
                Debug.WriteLine(HtmlResult);
                ProdutoDTO produtoDTO = JsonConvert.DeserializeObject<ProdutoDTO>(HtmlResult);
                return produtoDTO;
            }
        }

        public object atualizarProduto(Produto produto)
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(produto);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                Debug.WriteLine(dataString);
                var HtmlResult = client.UploadString(new Uri("http://localhost:9999/AlugueServiceWS/WS/Produto/Atualizar"), "PUT", dataString);
                Debug.WriteLine(HtmlResult);
                ProdutoDTO produtoDTO = JsonConvert.DeserializeObject<ProdutoDTO>(HtmlResult);
                return produtoDTO;
            }
        }
    }
}