using System.Web.Mvc;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers
{
    public class CidadeController : Controller
    {
        private readonly IServiceCidade serviceCidade;

        public CidadeController(IServiceCidade serviceCidade)
        {
            this.serviceCidade = serviceCidade;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxOption(string uf)
        {
            return PartialView(serviceCidade.Query(q => q.Uf == uf));
        }

        public JsonResult AjaxList()
        {
            return Json(serviceCidade.All(true), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AjaxAdd(Cidade cidade)
        {
            serviceCidade.Save(cidade);
            return Json(new { Status = true, Model = cidade });
        }

        [HttpPost]
        public JsonResult AjaxRemove(int id)
        {
            serviceCidade.Delete(id);
            return Json(new { Status = true });
        }
    }
}