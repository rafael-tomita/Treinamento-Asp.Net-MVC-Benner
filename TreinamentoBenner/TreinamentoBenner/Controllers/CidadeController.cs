using System.Web.Mvc;
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

        [HttpPost]
        public ActionResult AjaxOption(string uf)
        {
            return PartialView(serviceCidade.Query(q => q.Uf == uf));
        }
    }
}