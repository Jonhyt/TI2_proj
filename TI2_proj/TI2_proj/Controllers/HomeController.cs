using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TI2_proj.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private MusicasDB db = new MusicasDB();

        public ActionResult Index()
        {
            var musica = db.Musicas.Include(m => m.Album).Include(m => m.Artistas.Select(a => a.Artista));
            
            ViewBag.mEncontradas = null;

            return View(musica.ToList());
        }

        //HTML POST
        [HttpPost]
        public ActionResult Index(string tags)
        {
            var musica = db.Musicas.Include(m => m.Album).Include(m => m.Artistas.Select(a => a.Artista));
            ViewBag.mEncontradas = db.Musicas.Where(m => m.Titulo.Contains(tags)).ToList();
            return View(musica.ToList());
        }
        
        public ActionResult Search(int id,string attr)
        {
            IQueryable<Musicas> musica=null;
            if (attr == "mood")
            {
                musica = db.Musicas
                    .Where(
                        m => m.Moods.Select(g => g.MoodFK)
                        .Intersect(db.Musicas.Where(mus => mus.MusicaID == id).FirstOrDefault()
                        .Moods.Select(g => g.MoodFK)).Any());
            }
            if (attr == "genero")
            {
                musica = db.Musicas
                    .Where(
                        m => m.Generos.Select(g => g.GeneroFK)
                        .Intersect(db.Musicas.Where(mus => mus.MusicaID == id).FirstOrDefault()
                        .Generos.Select(g => g.GeneroFK)).Any());
            }
            if (attr == "compositor")
            {
                musica = db.Musicas
                    .Where(
                        m => m.Compositores.Select(g => g.CompositorFK)
                        .Intersect(db.Musicas.Where(mus => mus.MusicaID == id).FirstOrDefault()
                        .Compositores.Select(g => g.CompositorFK)).Any());
            }
            //NAO IMPLEMENTADO
            /*if (attr == "artista")
            {
                musica = db.Musicas
                    .Where(
                        m => m.Artistas.Select(g => g.ArtistaFK).Union(db.Bandas.Where(b => m.Artistas.Select(a => a.ArtistaFK).Contains(b.BandaFK)).Select(b => b.MembroFK))
                        .Intersect(db.Musicas.Where(mus => mus.MusicaID == id).FirstOrDefault()
                        .Artistas.Select(g => g.ArtistaFK).Union(db.Bandas.Where(b => db.Musicas.Where(mus => mus.MusicaID == id).FirstOrDefault().Artistas.Select(a => a.ArtistaFK).Contains(b.BandaFK)).Select(b => b.MembroFK))).Any());
            }*/
            ViewBag.musicaId = db.Musicas.Find(id).Titulo;
            switch (attr)
            {
                case "mood":
                    ViewBag.sortAttr = "Mood";
                    break;
                case "genero":
                    ViewBag.sortAttr = "Genres";
                    break;
                case "compositor":
                    ViewBag.sortAttr = "Composer";
                    break;

            }
            return View(musica
                    .Include(m => m.Album)
                    .Include(m => m.Artistas.Select(a => a.Artista))
                    .Include(m => m.Compositores.Select(a => a.Compositor))
                    .Include(m => m.Generos.Select(a => a.Genero))
                    .Include(m => m.Moods.Select(a => a.Mood)).ToList()
                    );
        }

        [Authorize]
        public ActionResult Menu()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
