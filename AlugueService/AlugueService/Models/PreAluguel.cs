using System;
using System.Collections.Generic;

namespace AlugueService.Models
    {
    public class PreAluguel
        {

        public int idPreAluguel { get; set; }
        public int operadorCriador { get; set; }
        public Cliente cliente { get; set; }
        public Configuracao configuracao { get; set; }
        public long dataPrevista { get; set; }
        public int statusPreAluguel { get; set; }
        public float valorAluguel { get; set; }
        public List<Produto> listaProdutos { get; set; }

        // Metodos construtores

        public PreAluguel()
        {

        }

        public PreAluguel(PreAluguel preAluguel)
        {
            idPreAluguel = preAluguel.idPreAluguel;
            operadorCriador = preAluguel.operadorCriador;
            cliente = preAluguel.cliente;
            configuracao = preAluguel.configuracao;
            dataPrevista = preAluguel.dataPrevista;
            statusPreAluguel = preAluguel.statusPreAluguel;
            valorAluguel = preAluguel.valorAluguel;
            listaProdutos = preAluguel.listaProdutos;
        }

        public PreAluguel(int id)
        {
            this.idPreAluguel = id;
        }
    }
    }