using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class AluguelController : Controller
    {
        // GET: Aluguel/Cadastro

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

        // GET: Aluguel/Consulta
        [HttpGet]
        public ActionResult Consulta()
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
    }
}