using System;
using System.Web.Mvc;
using TreinamentoBenner.Filters;

namespace TreinamentoBenner.Controllers
{
    [LogActionFilter]
    public class HistoricoController : Controller
    {
        public string Arquivo(DateTime data)
        {
            return string.Format("A data é {0:D}", data);
        }
    }
}