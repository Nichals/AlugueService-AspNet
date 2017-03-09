using System.Web.Mvc;

namespace AlugueService.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["idOperador"].ToString()))
                {
                    int produtosInativos = 1500;
                    int produtosAtivos = 255;
                    int produtosAlugados = 605;
                    int produtosPreAlugados = 605;
                    int produtosEmManutencao = 605;
                    int produtosEmLavagem = 100;

                    ViewBag.Valor = "[ {label: \" Inativos\", data: " + produtosInativos + ", color: \"#09276B\" },{ label: \" Ativos\", data: " + produtosAtivos + ", color: \"#0D3286\" },{ label: \" Alugados\", data: " + produtosAlugados + ", color: \"#244AA3\" },{ label: \" Pré-alugados\", data: " + produtosPreAlugados + ", color: \"#4465B2\" },{ label: \" Em manutenção\", data: " + produtosEmManutencao + ", color: \"#607FC5\" },{ label: \" Em lavagem\", data: " + produtosEmLavagem + ", color: \"#8CA5DD\" }]";


                    ViewBag.AlugueisAtivos = 10;
                    ViewBag.ProdutosCadastrados = 200;
                    ViewBag.ClientesCadastrados = 160;
                    ViewBag.OperadoresCadastrados = 8;
                    ViewBag.operadorLogado = Session["nomeOperador"].ToString();

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