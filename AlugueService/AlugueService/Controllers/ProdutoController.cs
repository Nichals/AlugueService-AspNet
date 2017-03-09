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
    public class ProdutoController : Controller
    {
        CultureInfo cult = new CultureInfo("pt-BR");

        // GET: Produto/Cadastro
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

                Produto produto = new Produto();
                Operador operador = new Operador();
                ProdutoDAL produtoDAL = new ProdutoDAL();

                produto.nome = Convert.ToString(collection["nome"]);
                produto.tamanho = Convert.ToString(collection["tamanho"]);
                produto.genero = Convert.ToString(collection["genero"]);
                produto.valor = float.Parse(collection["valor"], cult);
                produto.descricao = Convert.ToString(collection["descricao"]);
                DateTime currentDate = DateTime.Now;
                produto.dataCriacao = currentDate.Date.Ticks;
                produto.status = 1;
                produto.quantidadeAluguel = 0;
                produto.operadorCriador = (int)Session["idOperador"];
                produto.diretorioImagem = "diretorioImagem";

                var produtoDTO = produtoDAL.cadastrarProduto(produto);

                if (produtoDTO.ok == false)
                {
                    ViewBag.Mensagem = produtoDTO.mensagem;
                    return View("_ErroCadastro");
                }
                else
                {
                    ViewBag.Mensagem = "Produto " + produtoDTO.produto.nome + " cadastrado com sucesso";
                    ViewBag.Produto = produtoDTO.produto;
                    ViewBag.Etiqueta = produtoDTO.produto.idProduto;

                    return View("_SucessoProduto");
                }

            }
            catch
            {
                return View();
            }
        }


        // GET: Produto/Consulta
        //[HttpGet]
        //public ActionResult Consulta(int? pagina, string pesquisa, string filtro)
        //{
        //    ProdutoDAL produtoDAL = new ProdutoDAL();
        //    var produtoDTO = produtoDAL.pesquisarProduto();

        //    var produtos = from s in produtoDTO.lista select s;
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
        //        produtos = produtos.Where(s => s.nome.Contains(pesquisa));
        //    }

        //    int pageSize = 10;
        //    int pageNumber = (pagina ?? 1);
        //    ViewBag.lista = produtos.ToPagedList(pageNumber, pageSize);
        //    return View();

        //}

        [HttpGet]
        public ActionResult Consulta()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    ProdutoDAL produtoDAL = new ProdutoDAL();
                    var produtoDTO = produtoDAL.pesquisarProduto();

                    var produtos = from s in produtoDTO.lista select s;
                    ViewBag.lista = produtos;
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
            ProdutoDAL produtoDAL = new ProdutoDAL();
            var produtoDTO = produtoDAL.pesquisarProduto();

            var produtos = from s in produtoDTO.lista select s;
            var produto = new Produto();
            foreach (var item in produtoDTO.lista)
            {
                if (id == item.idProduto)
                {
                    produto = item;
                }

            }

            ViewBag.produto = produto;
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Editar(int id, int status)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    int nivelAux = (int)Session["nivelOperador"];
                    if (nivelAux == 1)
                    {
                        ProdutoDAL produtoDAL = new ProdutoDAL();
                        var produtoDTO = produtoDAL.pesquisarProduto();

                        if (status == 0 || status == 1)
                        {
                            return View(produtoDTO.lista.Find(x => x.idProduto == id));
                        }
                        else
                            TempData["AlertMessage"] = "Nao eh possivel editar um produto com o status alugado/pre-alugado/em manutencao/em lavagem";
                        return RedirectToAction("Consulta");
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
            ProdutoDAL produtoDAL = new ProdutoDAL();
            Produto produto = new Produto();

            var produtoDTO = produtoDAL.pesquisarProduto();

            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                produtoDTO.lista.Find(x => x.idProduto == id).nome = Convert.ToString(collection["nome"]);
                produtoDTO.lista.Find(x => x.idProduto == id).tamanho = Convert.ToString(collection["tamanho"]);
                produtoDTO.lista.Find(x => x.idProduto == id).genero = Convert.ToString(collection["genero"]);
                produtoDTO.lista.Find(x => x.idProduto == id).valor = float.Parse(collection["valor"], cult);
                produtoDTO.lista.Find(x => x.idProduto == id).descricao = Convert.ToString(collection["descricao"]);
                produtoDTO.lista.Find(x => x.idProduto == id).status = Convert.ToInt32(collection["status"]);

                produto = produtoDTO.lista.Find(x => x.idProduto == id);
                produto.diretorioImagem = "teste";

                var produtoDTO2 = produtoDAL.atualizarProduto(produto);

                return RedirectToAction("Consulta");
            }
            catch
            {
                return View();
            }
        }

    }
}