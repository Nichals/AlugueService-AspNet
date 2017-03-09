using AlugueService.DAL;
using AlugueService.DTO;
using AlugueService.Models;
using AlugueService.Util;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class ClienteController : Controller
    {
        CultureInfo cult = new CultureInfo("pt-BR");

        //static List<Cliente> listaDeClientes = new List<Cliente>();
        //static int idCliente = 1;

        // GET: Cliente/Cadastro
        [HttpGet]
        public ActionResult Cadastro()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    return View();
                }

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Cadastro(FormCollection collection)
        {
            try
            {

                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                Cliente cliente = new Cliente();
                Endereco endereco = new Endereco();
                Operador operador = new Operador();
                ClienteDAL clienteDAL = new ClienteDAL();
                ClienteDTO clienteDTO = new ClienteDTO();

                cliente.nome = Convert.ToString(collection["nome"]);
                cliente.sobrenome = Convert.ToString(collection["sobrenome"]);
                cliente.cpf = Convert.ToString(collection["cpf"]);
                DateTime dt = Convert.ToDateTime(collection["dataNascimento"]);
                cliente.dataNascimento = dt.Date.Ticks;
                cliente.email = Convert.ToString(collection["email"]);
                cliente.telefone = Convert.ToString(collection["telefone"]);
                cliente.celular = Convert.ToString(collection["celular"]);
                endereco.rua = Convert.ToString(collection["endereco.rua"]);
                endereco.bairro = Convert.ToString(collection["endereco.bairro"]);
                endereco.numero = Convert.ToString(collection["endereco.numero"]);
                endereco.cep = Convert.ToString(collection["endereco.cep"]);
                endereco.cidade = Convert.ToString(collection["endereco.cidade"]);
                cliente.endereco = endereco;
                cliente.status = 1;
                cliente.operadorCriador = (int)Session["idOperador"];
                DateTime currentDate = DateTime.Now;
                cliente.dataCriacao = currentDate.Date.Ticks;

                clienteDTO = clienteDAL.cadastrarCliente(cliente);

                if (clienteDTO.ok == false)
                {
                    ViewBag.Mensagem = clienteDTO.mensagem;
                    return View("_ErroCadastro");
                }
                else
                {
                    ViewBag.Mensagem = "Cliente " + cliente.nome + " " + cliente.sobrenome + " cadastrado/a com sucesso!";//" CPF: " + cliente.cpf + " Data de nascimento: " + dta + " Email: " + cliente.email + " Telefone: " + cliente.telefone + " Celular: " + cliente.celular + " Rua: " + cliente.rua + " Bairro: " + cliente.bairro + " Número: " + cliente.numero + " CEP: " + cliente.cep + " Cidade: " + cliente.cidade;

                    return View("_Sucesso");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Consulta
        //[HttpGet]
        //public ActionResult Consulta(int? pagina, string pesquisa, string filtro)
        //{
        //    ClienteDAL clienteDAL = new ClienteDAL();
        //    var clienteDTO = clienteDAL.pesquisarCliente();

        //    var clientes = from s in clienteDTO.lista select s;
        //    if (pesquisa != null)
        //    {
        //        pagina = 1;
        //    }
        //    else
        //    {
        //        pesquisa = filtro;
        //    }

        //    if (!String.IsNullOrEmpty(pesquisa))
        //    {
        //        clientes = clientes.Where(s => s.nome.Contains(pesquisa));
        //    }

        //    int pageSize = 10;
        //    int pageNumber = (pagina ?? 1);
        //    ViewBag.lista = clientes.ToPagedList(pageNumber, pageSize);
        //    return View();

        //}

        // GET: Cliente/Consulta
        [HttpGet]
        public ActionResult Consulta()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    ClienteDAL clienteDAL = new ClienteDAL();
                    var clienteDTO = clienteDAL.pesquisarCliente();

                    var clientes = from s in clienteDTO.lista select s;
                    ViewBag.lista = clientes;
                    return View();
                }

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");

        }


        public ActionResult Modal(int id)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            var clienteDTO = clienteDAL.pesquisarCliente();

            var clientes = from s in clienteDTO.lista select s;
            var cliente = new Cliente();
            foreach (var item in clienteDTO.lista)
            {
                if (id == item.idCliente)
                {
                    cliente = item;
                }

            }

            ViewBag.cliente = cliente;
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    ClienteDAL clienteDAL = new ClienteDAL();
                    var clienteDTO = clienteDAL.pesquisarCliente();

                    ViewBag.teste = "teste";
                    return View(clienteDTO.lista.Find(x => x.idCliente == id));
                }

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteDTO clienteDTO2 = new ClienteDTO();
            Cliente cliente = new Cliente();

            var clienteDTO = clienteDAL.pesquisarCliente();
            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                clienteDTO.lista.Find(x => x.idCliente == id).nome = Convert.ToString(collection["nome"]);
                clienteDTO.lista.Find(x => x.idCliente == id).sobrenome = Convert.ToString(collection["sobrenome"]);
                clienteDTO.lista.Find(x => x.idCliente == id).cpf = Convert.ToString(collection["cpf"]);
                DateTime dt = Convert.ToDateTime(collection["dataNascimento"]);
                clienteDTO.lista.Find(x => x.idCliente == id).dataNascimento = dt.Date.Ticks;
                clienteDTO.lista.Find(x => x.idCliente == id).email = Convert.ToString(collection["email"]);
                clienteDTO.lista.Find(x => x.idCliente == id).telefone = Convert.ToString(collection["telefone"]);
                clienteDTO.lista.Find(x => x.idCliente == id).celular = Convert.ToString(collection["celular"]);
                clienteDTO.lista.Find(x => x.idCliente == id).endereco.rua = Convert.ToString(collection["endereco.rua"]);
                clienteDTO.lista.Find(x => x.idCliente == id).endereco.bairro = Convert.ToString(collection["endereco.bairro"]);
                clienteDTO.lista.Find(x => x.idCliente == id).endereco.numero = Convert.ToString(collection["endereco.numero"]);
                clienteDTO.lista.Find(x => x.idCliente == id).endereco.cep = Convert.ToString(collection["endereco.cep"]);
                clienteDTO.lista.Find(x => x.idCliente == id).endereco.cidade = Convert.ToString(collection["endereco.cidade"]);
                clienteDTO.lista.Find(x => x.idCliente == id).status = Convert.ToInt32(collection["status"]);

                cliente = clienteDTO.lista.Find(x => x.idCliente == id);
                clienteDTO2 = clienteDAL.atualizarCliente(cliente);

                if (clienteDTO2.ok == false)
                {
                    ViewBag.Mensagem = clienteDTO2.mensagem;
                    return View("_ErroCadastro");
                }
                else
                    return RedirectToAction("Consulta");
            }
            catch
            {
                return View();
            }
        }


        // METODO PARA POPULAR LISTA
        public List<Cliente> GetCliente()
        {

            List<Cliente> lista = new List<Cliente>();
            for (int i = 0; i < 50; i++)
            {
                var cliente = new Cliente();
                cliente.idCliente = i;
                cliente.nome = "testerino" + i;
                cliente.sobrenome = "teste";
                cliente.cpf = "cpf" + i * i + i * i;
                cliente.dataNascimento = 0;
                cliente.email = "testerino@email.com";
                cliente.telefone = "(33)3333-3333";
                cliente.celular = "(44)3333-3333";
                cliente.endereco.rua = "Rua teste";
                cliente.endereco.bairro = "Bairro teste";
                cliente.endereco.numero = "123a";
                cliente.endereco.cidade = "Cidade teste";
                cliente.endereco.cep = "12312-312";
                cliente.status = 1;
                cliente.dataCriacao = 0;
                lista.Add(cliente);
            }
            var cliente2 = new Cliente();
            cliente2.nome = "testerinoInativo";
            cliente2.idCliente = 111;
            cliente2.cpf = "cpf" + 1;
            cliente2.dataNascimento = 0;
            cliente2.email = "testerino@email.com";
            cliente2.telefone = "(33)3333-3333";
            cliente2.celular = "(44)3333-3333";
            cliente2.endereco.rua = "Rua teste";
            cliente2.endereco.bairro = "Bairro teste";
            cliente2.endereco.numero = "123a";
            cliente2.endereco.cidade = "Cidade teste";
            cliente2.endereco.cep = "12312-312";
            cliente2.status = 0;
            cliente2.dataCriacao = 0;
            lista.Add(cliente2);
            return lista;
        }

    }
}
