using System.Web.Mvc;
using TreinamentoBenner.Context;

namespace TreinamentoBenner.Controllers
{
    public class GeneroController : Controller
    {
        private readonly LojaContext db = new LojaContext();
        // GET: Genero
        public ActionResult Index()
        {
            return View(db.Generos);
        }
    }
}