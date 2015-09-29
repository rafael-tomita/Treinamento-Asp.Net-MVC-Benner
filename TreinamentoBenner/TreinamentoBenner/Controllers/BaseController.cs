using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoBenner.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetCulture(Request);
            base.OnActionExecuting(filterContext);
        }

        private static void SetCulture(HttpRequestBase request)
        {
            if (request == null) return;
            if (request.UserLanguages == null) return;
            if (request.UserLanguages.Length <= 0) return;

            var cultureName = request.UserLanguages[0];
            SetCulture(cultureName);
        }

        private static void SetCulture(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture
                = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}