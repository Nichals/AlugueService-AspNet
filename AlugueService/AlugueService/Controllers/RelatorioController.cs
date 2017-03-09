using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        [HttpGet]
        public ActionResult Index()
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