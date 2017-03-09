using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugueService.Models
{
    public class Aluguel
    {
        public Aluguel()
        {

        }

        public int idAluguel { get; set; }
        public Operador operadorCriador { get; set; }
        public Cliente cliente { get; set; }
        public Configuracao configuracao { get; set; }
        public Cupom cupom { get; set; }
        public PreAluguel preAluguel { get; set; }
        public DateTime dataAluguel { get; set; }
        public DateTime dataPrevista { get; set; }
        public DateTime dataEntrega { get; set; }
        public int statusAluguel { get; set; }
        public int quantidadeMulta { get; set; }
        public float valorAluguel { get; set; }
        public float valorMulta { get; set; }
        public float valorTotal { get; set; }
        public Operador operadorFinalizador { get; set; }
        public List<Produto> listaProdutos { get; set; }
    }
}