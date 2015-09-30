using System.Linq;
using System.Web.Mvc;
using TreinamentoBenner.Context;
using TreinamentoBenner.Models;

namespace TreinamentoBenner.Controllers
{
    [Authorize]
    public class AlbumController : BaseController
    {
        private readonly LojaContext _db = new LojaContext();

        public ActionResult Index()
        {
            var albums = from album in _db.Albums
                orderby album.Titulo ascending
                select album;

            return View(albums);
        }

        public ActionResult Create()
        {
            Dropdown();

            return View();
        }

        private void Dropdown(Album album = null)
        {
            ViewBag.ArtistaId = new SelectList(_db.Artistas, "Id", "Nome", album?.ArtistaId);
            ViewBag.GeneroId = new SelectList(_db.Generos, "Id", "Nome", album?.GeneroId);
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            //var Titulo = form["Titulo"];
            //var generoId = Convert.ToInt32(Request.Form["GeneroId"]);

            //ModelState.AddModelError("Titulo", "Que nome terrível!");

            if (ModelState.IsValid)
            {
                _db.Albums.Add(album);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            Dropdown();
            return View(album);
        }

        public ActionResult Search(string q)
        {
            IQueryable<Album> query = _db.Albums.OrderBy(m => m.Titulo);
            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(m => m.Titulo.Contains(q));
            }

            return View(query);
        }
    }
}
