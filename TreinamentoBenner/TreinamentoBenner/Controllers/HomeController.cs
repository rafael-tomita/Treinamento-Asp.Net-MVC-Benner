using System;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Filters;

namespace TreinamentoBenner.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Browse(string genre)
        {
            var message = HttpUtility.HtmlEncode(
                    "Store.Browse, Genre = " + genre
                );
            return message;
        }

        public string Details(int id)
        {
            return "Loja.Details, ID = " + id;
        }

        public ActionResult Today()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            var date = DateTime.Now;
            return View(date);
        }
        
        public ActionResult Blah()
        {
            return RedirectToRoute("Historico", new { data = "2015-05-02" });
        }
    }
}