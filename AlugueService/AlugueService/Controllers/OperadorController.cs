using AlugueService.DAL;
using AlugueService.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class OperadorController : Controller
    {
        CultureInfo cult = new CultureInfo("pt-BR");

        //static List<Operador> listaDeOperadores = new List<Operador>();
        //static int idOperador = 0;

        // GET: Operador/Cadastro
        [HttpGet]
        public ActionResult Cadastro()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    int nivelAux = (int)Session["nivelOperador"];
                    if (nivelAux == 1)
                    {
                        return View();
                    }
                    else
                    {
                        return View("_AcessoNegado");
                    }
                }

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Cadastro(FormCollection collection)
        {
            try
            {

                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                Operador operador = new Operador();
                Endereco endereco = new Endereco();
                OperadorDAL operadorDAL = new OperadorDAL();

                operador.nome = Convert.ToString(collection["nome"]);
                operador.sobrenome = Convert.ToString(collection["sobrenome"]);
                operador.cpf = Convert.ToString(collection["cpf"]);
                DateTime dt = Convert.ToDateTime(collection["dataNascimento"]);
                operador.dataNascimento = dt.Date.Ticks;
                operador.email = Convert.ToString(collection["email"]);
                operador.telefone = Convert.ToString(collection["telefone"]);
                operador.celular = Convert.ToString(collection["celular"]);
                endereco.rua = Convert.ToString(collection["endereco.rua"]);
                endereco.bairro = Convert.ToString(collection["endereco.bairro"]);
                endereco.numero = Convert.ToString(collection["endereco.numero"]);
                endereco.cep = Convert.ToString(collection["endereco.cep"]);
                endereco.cidade = Convert.ToString(collection["endereco.cidade"]);
                operador.endereco = endereco;
                operador.login = Convert.ToString(collection["login"]);
                operador.senha = Convert.ToString(collection["senha"]);
                operador.nivel = Convert.ToInt32(collection["nivel"]);
                operador.status = 1;
                operador.operadorCriador = (int)Session["idOperador"];
                DateTime currentDate = DateTime.Now;
                operador.dataCriacao = currentDate.Date.Ticks;

                var operadorDTO = operadorDAL.cadastrarOperador(operador);

                if (operadorDTO.ok == false)
                {
                    ViewBag.Mensagem = operadorDTO.mensagem;
                    return View("_ErroCadastro");
                }
                else
                {
                    ViewBag.Mensagem = "Operador " + operador.nome + " " + operador.sobrenome + " cadastrado/a com sucesso! ";//+ " CPF: " + operador.cpf + " Data de nascimento: " + dta + " Email: " + operador.email +" Telefone: "+operador.telefone+" Celular: " +operador.celular + " Rua: " + operador.rua + " Bairro: " + operador.bairro + " Número: " + operador.numero + " CEP: " + operador.cep + " Cidade: " + operador.cidade + " Login: " + operador.login + " Senha: " + operador.senha + " Nivel " + operador.nivel;

                    return View("_Sucesso");
                }

            }
            catch
            {
                return View();
            }
        }


        // GET: Operador/Consulta
        //[HttpGet]
        //public ActionResult Consulta(int? pagina, string pesquisa, string filtro)
        //    {

        //    OperadorDAL operadorDAL = new OperadorDAL();
        //    var operadorDTO = operadorDAL.pesquisarOperador();

        //    var operadores = from s in operadorDTO.lista select s;
        //    if (pesquisa != null)
        //        {
        //        pagina = 1;
        //        }
        //    else
        //        {
        //        pesquisa = filtro;
        //        }

        //    if (!String.IsNullOrEmpty(pesquisa))
        //        {
        //        operadores = operadores.Where(s => s.nome.Contains(pesquisa));
        //        }

        //    int pageSize = 10;
        //    int pageNumber = (pagina ?? 1);
        //    ViewBag.lista = operadores.ToPagedList(pageNumber, pageSize);
        //    return View();

        //    }


        // GET: Operador/Consulta
        [HttpGet]
        public ActionResult Consulta()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    OperadorDAL operadorDAL = new OperadorDAL();
                    var operadorDTO = operadorDAL.pesquisarOperador();

                    var operadores = from s in operadorDTO.lista select s;
                    ViewBag.lista = operadores;
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
            OperadorDAL operadorDAL = new OperadorDAL();
            var operadorDTO = operadorDAL.pesquisarOperador();


            var operadores = from s in operadorDTO.lista select s;
            var operador = new Operador();
            foreach (var item in operadorDTO.lista)
            {
                if (id == item.idOperador)
                {
                    operador = item;
                }

            }

            ViewBag.operador = operador;
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    int nivelAux = (int)Session["nivelOperador"];
                    if (nivelAux == 1)
                    {
                        OperadorDAL operadorDAL = new OperadorDAL();
                        var operadorDTO = operadorDAL.pesquisarOperador();
                        return View(operadorDTO.lista.Find(x => x.idOperador == id));
                    }
                    else
                    {
                        return View("_AcessoNegado");
                    }
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
            OperadorDAL operadorDAL = new OperadorDAL();
            Operador operador = new Operador();

            var operadorDTO = operadorDAL.pesquisarOperador();
            try
            {

                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                operadorDTO.lista.Find(x => x.idOperador == id).nome = Convert.ToString(collection["nome"]);
                operadorDTO.lista.Find(x => x.idOperador == id).sobrenome = Convert.ToString(collection["sobrenome"]);
                operadorDTO.lista.Find(x => x.idOperador == id).cpf = Convert.ToString(collection["cpf"]);
                DateTime dt = Convert.ToDateTime(collection["dataNascimento"]);
                operadorDTO.lista.Find(x => x.idOperador == id).dataNascimento = dt.Date.Ticks;
                operadorDTO.lista.Find(x => x.idOperador == id).email = Convert.ToString(collection["email"]);
                operadorDTO.lista.Find(x => x.idOperador == id).telefone = Convert.ToString(collection["telefone"]);
                operadorDTO.lista.Find(x => x.idOperador == id).celular = Convert.ToString(collection["celular"]);
                operadorDTO.lista.Find(x => x.idOperador == id).endereco.rua = Convert.ToString(collection["endereco.rua"]);
                operadorDTO.lista.Find(x => x.idOperador == id).endereco.bairro = Convert.ToString(collection["endereco.bairro"]);
                operadorDTO.lista.Find(x => x.idOperador == id).endereco.numero = Convert.ToString(collection["endereco.numero"]);
                operadorDTO.lista.Find(x => x.idOperador == id).endereco.cep = Convert.ToString(collection["endereco.cep"]);
                operadorDTO.lista.Find(x => x.idOperador == id).endereco.cidade = Convert.ToString(collection["endereco.cidade"]);
                operadorDTO.lista.Find(x => x.idOperador == id).status = Convert.ToInt32(collection["status"]);
                operadorDTO.lista.Find(x => x.idOperador == id).login = Convert.ToString(collection["login"]);
                operadorDTO.lista.Find(x => x.idOperador == id).senha = Convert.ToString(collection["senha"]);
                operadorDTO.lista.Find(x => x.idOperador == id).nivel = Convert.ToInt32(collection["nivel"]);

                operador = operadorDTO.lista.Find(x => x.idOperador == id);
                var operadorDTO2 = operadorDAL.atualizarOperador(operador);

                if (operadorDTO2.ok == false)
                {
                    ViewBag.Mensagem = operadorDTO2.mensagem;
                    return View("_ErroCadastro");
                }
                else
                {
                    return RedirectToAction("Consulta");
                }
            }
            catch
            {
                return View();
            }
        }


        // METODO PARA POPULAR LISTA
        public List<Operador> GetOperador()
        {

            List<Operador> lista = new List<Operador>();
            for (int i = 0; i < 50; i++)
            {
                var operador = new Operador();
                operador.idOperador = i;
                operador.nome = "Testerino" + i;
                operador.sobrenome = "Operador";
                operador.cpf = "cpf" + i * i + i * i;
                //operador.dataNascimento = DateTime.Today;
                operador.email = "testerino@email.com";
                operador.telefone = "(33)3333-3333";
                operador.celular = "(44)3333-3333";
                operador.endereco.rua = "Rua teste";
                operador.endereco.bairro = "Bairro teste";
                operador.endereco.numero = "123a";
                operador.endereco.cidade = "Cidade teste";
                operador.endereco.cep = "12312-312";
                operador.status = 1;
                operador.login = "opera" + i;
                operador.senha = "1234";
                operador.nivel = 1;
                //operador.dataCriacao = DateTime.Today;
                //operador.idOperadorOperadorCriador = i;
                lista.Add(operador);
            }
            var operador2 = new Operador();
            operador2.nome = "testerinoInativo";
            operador2.sobrenome = "Operador";
            operador2.idOperador = 111;
            operador2.cpf = "cpf" + 1;
            //operador2.dataNascimento = DateTime.Today;
            operador2.email = "testerino@email.com";
            operador2.telefone = "(33)3333-3333";
            operador2.celular = "(44)3333-3333";
            operador2.endereco.rua = "Rua teste";
            operador2.endereco.bairro = "Bairro teste";
            operador2.endereco.numero = "123a";
            operador2.endereco.cidade = "Cidade teste";
            operador2.endereco.cep = "12312-312";
            operador2.status = 0;
            operador2.login = "operaIna";
            operador2.senha = "1234";
            operador2.nivel = 1;
            //operador2.dataCriacao = DateTime.Today;
            //operador2.idOperadorCriador = 1;
            lista.Add(operador2);
            return lista;
        }


    }

}