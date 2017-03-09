using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.DTO
{
    public class OperadorDTO
    {
        private bool v1;
        private string v2;
        private Operador tOperador;
        public OperadorDTO()
        {

        }

        public OperadorDTO(bool pOk, string pMensagem, Operador pOperador)
        {
            this.ok = pOk;
            this.mensagem = pMensagem;
            this.operador = pOperador;
        }

        public OperadorDTO(bool pOk, string pMensagem)
        {
            this.ok = pOk;
            this.mensagem = pMensagem;
        }

        public OperadorDTO(bool ok, string mensagem, List<Operador> lista)
        {
            this.ok = ok;
            this.mensagem = mensagem;
            this.lista = lista;
        }

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Operador> lista { get; set; }
        public Operador operador { get; set; }

    }
}