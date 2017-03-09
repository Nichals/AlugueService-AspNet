using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    public class PreAluguelDTO 
    {
        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<PreAluguel> lista { get; set; }
        public PreAluguel preAluguel { get; set; }
    }
}