using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI2_proj.Models;

namespace TI2_proj.Controllers
{
    public class MusicasController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: Musicas
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.Musicas.Include(m => m.Album).ToList());
            return View(db.Musicas.Where(a => a.Dono == User.Identity.Name).Include(m => m.Album).ToList());
        }

        // GET: Musicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicas musicas = db.Musicas.Find(id);
            if (musicas == null)
            {
                return HttpNotFound();
            }
            return View(musicas);
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Titulo");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusicaID,Titulo,Duracao,NumFaixa,AlbumFK")] Musicas musicas,string acao)
        {
            if (ModelState.IsValid)
            {
                musicas.Dono = User.Identity.Name;
                db.Musicas.Add(musicas);
                db.SaveChanges();
                switch (acao)
                {
                    case "Create":
                        return RedirectToAction("Index");
                    case "Add Artists":
                        return RedirectToAction("AdArtista",new { id = musicas.MusicaID });
                }
            }

            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Titulo", musicas.AlbumFK);
            return View(musicas);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicas musicas = db.Musicas.Find(id);
            if (musicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Titulo", musicas.AlbumFK);
            return View(musicas);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusicaID,Titulo,Duracao,NumFaixa,AlbumFK")] Musicas musicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Titulo", musicas.AlbumFK);
            return View(musicas);
        }

        public ActionResult AdArtista(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicas musicas = db.Musicas.Include(m => m.Artistas).Where(m => m.MusicaID == id).FirstOrDefault();
            PopulateAssignedArtistData(musicas);
            ViewBag.ArtistaFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            if (musicas == null)
            {
                return HttpNotFound();
            }
            var userRoles = musicas.Artistas;


            return View(musicas);
        }

        private void PopulateAssignedArtistData(Musicas musica)
        {
            var allArtistas = db.Artista;
            //var instructorCourses = new HashSet<int>(musica.Artistas.Select(c => c.Artista.ArtistaID));
            var viewModel = new List<Artista>();
            foreach (var art in allArtistas)
            {
                viewModel.Add(new Artista
                {
                    ArtistaID = art.ArtistaID,
                    Nome = art.Nome,
                });
            }
            ViewBag.Artistas = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdArtista(int? id, string[] selectedArt)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicas musicasToUpdate = db.Musicas.Include(m => m.Artistas).Where(m => m.MusicaID == id).FirstOrDefault();

            if (TryUpdateModel(musicasToUpdate, "",
               new string[] { "Artistas" }))
            {
                try
                {
                    UpdateMusicaArtista(selectedArt, musicasToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedArtistData(musicasToUpdate);
            return View(musicasToUpdate);
        }
        private void UpdateMusicaArtista(string[] selectedArt, Musicas musicasToUpdate)
        {
            if (selectedArt == null)
            {
                musicasToUpdate.Artistas =new List<ArtistaMusica>();
                return;
            }

            var selectedArtHS = new HashSet<string>(selectedArt);
            var instructorCourses = new HashSet<int>
                (musicasToUpdate.Artistas.Select(c => c.ArtistaFK));
            foreach (var art in db.Artista)
            {
                if (selectedArtHS.Contains(art.ArtistaID.ToString()))
                {
                    if (!instructorCourses.Contains(art.ArtistaID))
                    {
                        musicasToUpdate.Artistas.Add(new ArtistaMusica() { ArtistaFK=art.ArtistaID, MusicaFK=musicasToUpdate.MusicaID });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(art.ArtistaID))
                    {
                        musicasToUpdate.Artistas.Remove(musicasToUpdate.Artistas.Where(m=> m.MusicaFK==musicasToUpdate.MusicaID).Where(a => a.ArtistaFK==art.ArtistaID).FirstOrDefault());
                    }
                }
            }
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicas musicas = db.Musicas.Find(id);
            if (musicas == null)
            {
                return HttpNotFound();
            }
            return View(musicas);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musicas musicas = db.Musicas.Find(id);
            db.Musicas.Remove(musicas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
