using System.Web.Mvc;
using System.Web.Security;
using TreinamentoBenner.Facade;

namespace TreinamentoBenner.Controllers
{
    [AllowAnonymous]
    public class AccounttController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated && SessionFacade.Usuario != null)
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            //validacao
            SessionFacade.Usuario = usuario;

            FormsAuthentication.SetAuthCookie(usuario.Login, true);
            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            SessionFacade.Usuario = null;

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}