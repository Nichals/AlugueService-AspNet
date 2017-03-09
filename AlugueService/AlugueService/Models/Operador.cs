using System;

namespace AlugueService.Models
    {
    public class Operador
        {

        public int idOperador { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public long dataNascimento { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int status { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int nivel { get; set; }
        public long dataCriacao { get; set; }
        public int? operadorCriador { get; set; }
        public Endereco endereco { get; set; }

        //Metodos construtores
        public Operador()
        {

        }

        public Operador(Operador operador)
        {
            idOperador = operador.idOperador;
            nome = operador.nome;
            sobrenome = operador.sobrenome;
            cpf = operador.cpf;
            dataNascimento = operador.dataNascimento;
            email = operador.email;
            telefone = operador.telefone;
            celular = operador.celular;
            endereco.rua = operador.endereco.rua;
            endereco.bairro = operador.endereco.bairro;
            endereco.numero = operador.endereco.numero;
            endereco.cidade = operador.endereco.cidade;
            endereco.cep = operador.endereco.cep;
            status = operador.status;
            login = operador.login;
            senha = operador.senha;
            nivel = operador.nivel;
            dataCriacao = operador.dataCriacao;
            

        }

        public Operador(int idOperador)
        {
            this.idOperador = idOperador;
        }

    }
    }