using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    public class ConfiguracaoDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Configuracao> lista { get; set; }
        public Configuracao configuracao { get; set; }
    }
}