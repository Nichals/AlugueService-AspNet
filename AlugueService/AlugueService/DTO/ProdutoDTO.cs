using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    public class ProdutoDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Produto> lista { get; set; }
        public Produto produto { get; set; }
    }
}