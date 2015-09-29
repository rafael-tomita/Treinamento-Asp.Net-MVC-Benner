using System.Web.Mvc;

namespace TreinamentoBenner.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString LinkVoltar(this HtmlHelper htmlHelper, 
            string idLink, string texto = "Voltar")
        {
            var stringLink = $"<a id='{idLink}' href='javascript:history.go(-1);'>{texto}</a>";

            return new MvcHtmlString(stringLink);
        }
    }
}