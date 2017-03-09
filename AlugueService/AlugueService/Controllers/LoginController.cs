using AlugueService.DAL;
using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {

                for (int i = 0; i < collection.Count; i++)
                {
                    Debug.WriteLine(collection[i]);
                }

                Operador operador = new Operador();
                OperadorDAL operadorDAL = new OperadorDAL();

                operador.login = Convert.ToString(collection["login"]);
                operador.senha = Convert.ToString(collection["senha"]);

                var operadorDTO = operadorDAL.autenticarOperador(operador);

                if (operadorDTO.ok == false)
                {
                    TempData["AlertMessage"] = operadorDTO.mensagem;
                    return RedirectToAction("Index");
                }
                else
                {
                    Session.Add("idOperador", operadorDTO.operador.idOperador);
                    Session.Add("nomeOperador", operadorDTO.operador.nome);
                    Session.Add("nivelOperador", operadorDTO.operador.nivel);
                    Debug.WriteLine(Session["idOperador"].ToString());
                    Debug.WriteLine(Session["nomeOperador"].ToString());
                    Debug.WriteLine(Session["nivelOperador"].ToString());

                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}