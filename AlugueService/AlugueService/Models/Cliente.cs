using System;
using System.ComponentModel.DataAnnotations;

namespace AlugueService.Models
{
    public class Cliente
    {

        public int idCliente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public long dataNascimento { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int status { get; set; }
        public long dataCriacao { get; set; }
        public int? operadorCriador { get; set; }
        public Endereco endereco { get; set; }

        //Metodos construtores
        public Cliente()
        {

        }

        public Cliente(Cliente cliente)
        {
            idCliente = cliente.idCliente;
            nome = cliente.nome;
            sobrenome = cliente.sobrenome;
            cpf = cliente.cpf;
            dataNascimento = cliente.dataNascimento;
            email = cliente.email;
            telefone = cliente.telefone;
            celular = cliente.celular;
            endereco.rua = cliente.endereco.rua;
            endereco.bairro = cliente.endereco.bairro;
            endereco.numero = cliente.endereco.numero;
            endereco.cidade = cliente.endereco.cidade;
            endereco.cep = cliente.endereco.cep;
            status = cliente.status;
            dataCriacao = cliente.dataCriacao;

            operadorCriador = cliente.operadorCriador;
            

        }

        public Cliente(int idCliente)
        {
            this.idCliente = idCliente;
        }


    }
}
