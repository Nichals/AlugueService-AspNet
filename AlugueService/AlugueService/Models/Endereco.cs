using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.Models
{
    public class Endereco
    {

        public string rua { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }

        //Metodos construtores
        public Endereco()
        {

        }

        //public Endereco(Endereco endereco)
        //{

        //    rua = endereco.rua;
        //    bairro = endereco.bairro;
        //    numero = endereco.numero;
        //    cidade = endereco.cidade;
        //    cep = endereco.cep;

        //}

    }

}