using AlugueService.DAL;
using AlugueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class PreAluguelController : Controller
    {
        // GET: PreAluguel
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {

                    PreAluguelDAL preAluguelDAL = new PreAluguelDAL();
                    var preAluguelDTO = preAluguelDAL.pesquisarPreAluguel();

                    var prealugueis = from s in preAluguelDTO.lista select s;
                    ViewBag.lista = prealugueis;
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
            PreAluguelDAL preAluguelDAL = new PreAluguelDAL();
            var preAluguelDTO = preAluguelDAL.pesquisarPreAluguel();

            var prealugueis = from s in preAluguelDTO.lista select s;
            var preAluguel = new PreAluguel();
            foreach (var item in preAluguelDTO.lista)
            {
                if (id == item.idPreAluguel)
                {
                    preAluguel = item;
                }

            }
            ViewBag.preAluguel = preAluguel;
            return PartialView("Modal");
        }

    }
}