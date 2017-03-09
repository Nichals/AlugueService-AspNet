using AlugueService.DAL;
using AlugueService.DTO;
using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class ConfiguracaoController : Controller
    {
        CultureInfo cult = new CultureInfo("pt-BR");
        static Configuracao configuracaoAtual = new Configuracao();
        //static int idConfiguracao = 1;


        // GET: Configuracao/Cadastro
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    int nivelAux = (int)Session["nivelOperador"];
                    if (nivelAux == 1)
                    {
                        ConfiguracaoDTO confDTO = new ConfiguracaoDTO();
                        ConfiguracaoDAL confDAL = new ConfiguracaoDAL();

                        confDTO = confDAL.pesquisarUltimo();

                        ViewBag.configuracao = confDTO.configuracao;
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
        //[ValidateInput(false)]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                Configuracao configuracao = new Configuracao();
                ConfiguracaoDTO confDTO = new ConfiguracaoDTO();
                ConfiguracaoDAL confDAL = new ConfiguracaoDAL();
                Configuracao configuracaoM = new Configuracao();

                //configuracao.id = ++idConfiguracao;
                configuracao.multa = float.Parse(collection["multa"], cult);
                configuracao.cupom = float.Parse(collection["cupom"], cult);
                //configuracao.contrato = Convert.ToString(collection["contrato"]);
                //configuracao.contrato = configuracao.contrato.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&").Replace("&#59;", ";").Replace("&quot;", "\"").Replace("&#47;","/");

                configuracao.contrato = "teste";

                confDTO = confDAL.cadastrarConfiguracao(configuracao);

                if (confDTO.ok == false)
                {
                    ViewBag.Mensagem = confDTO.mensagem;
                    return View("_ErroCadastro");
                }
                else
                {
                    configuracaoAtual = confDTO.configuracao;
                    ViewBag.configuracao = configuracaoAtual;
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

    }
}