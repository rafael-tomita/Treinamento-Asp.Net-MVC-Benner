using System.Linq;
using System.Web.Mvc;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly IServiceTelefone serviceTelefone;

        public TelefoneController(IServiceTelefone serviceTelefone)
        {
            this.serviceTelefone = serviceTelefone;
        }

        public ActionResult DialogForm()
        {
            return PartialView(new Telefone());
        }

        public ActionResult AjaxList(int id)
        {
            return PartialView(serviceTelefone.ListarPorPessoa(id));
        }

        [HttpPost]
        public JsonResult AjaxAdd(Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Message = ModelState.Values.Select(q => q.Value),
                    Status = false
                });
            }    

            serviceTelefone.Save(telefone);
            return Json(new
            {
                Message = "Telefone inserido com sucesso!",
                Status = true
            });
        }

        [HttpPost]
        public JsonResult AjaxRemove(int id)
        {
            serviceTelefone.Delete(id);
            return Json(new
            {
                Message = "Telefone excluido com sucesso",
                Status = true
            });
        }
    }
}