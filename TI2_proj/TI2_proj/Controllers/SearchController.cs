using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using TI2_proj.Models;

namespace TI2_proj.Controllers
{
    public class SearchController : Controller
    {
        private MusicasDB db = new MusicasDB();
        // GET: Search
        public ActionResult Index()
        {

            var musica = db.Musicas.Include(m => m.Album).Include(m => m.Artistas);

            return View(musica.ToList());
        }
    }
}