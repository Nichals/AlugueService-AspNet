using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.Models
{
    public class Configuracao
    {
        public Configuracao()
        {

        }

        public int idConfiguracao { get; set; }
        public float multa { get; set; }
        public float cupom { get; set; }
        public String contrato { get; set; }

    }
}