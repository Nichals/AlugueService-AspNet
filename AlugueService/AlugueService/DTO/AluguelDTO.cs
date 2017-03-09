using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    class AluguelDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Aluguel> lista { get; set; }
        public Aluguel aluguel { get; set; }
    }
}