using System.Web.Mvc;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IServicePessoa _servicePessoa;

        public PessoaController(IServicePessoa servicePessoa)
        {
            _servicePessoa = servicePessoa;
        }

        public ActionResult Index()
        {
            return View(_servicePessoa.All(true));
        }

        public ActionResult Create(int? id)
        {
            return id == null ? View(new Pessoa()) : View(_servicePessoa.Find(id.Value) ?? new Pessoa());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            if (!ModelState.IsValid) return View(pessoa);

            _servicePessoa.Save(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(_servicePessoa.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _servicePessoa.Delete(id);
            return RedirectToAction("Index");
        }
    }
}