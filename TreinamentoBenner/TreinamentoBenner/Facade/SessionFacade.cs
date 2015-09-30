using System.Web;

namespace TreinamentoBenner.Facade
{
    public static class SessionFacade
    {
        private const string SESSION_USUARIO = "Usuario";

        public static Usuario Usuario
        {
            get
            {
                return HttpContext.Current.Session != null ?
                    HttpContext.Current.Session[SESSION_USUARIO] as Usuario : null;
            }
            set { HttpContext.Current.Session[SESSION_USUARIO] = value; }
        }
    }
}