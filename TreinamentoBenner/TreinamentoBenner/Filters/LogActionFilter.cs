using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Routing;

namespace TreinamentoBenner.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        private static void Log(RouteData routeData, [CallerMemberName]string methodName = "")
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = $"{methodName} controller: {controllerName} action: {actionName}";
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}