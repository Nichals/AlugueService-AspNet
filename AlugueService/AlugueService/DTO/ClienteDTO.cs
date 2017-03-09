using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    public class ClienteDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Cliente> lista { get; set; }
        public Cliente cliente { get; set; }
    }
}