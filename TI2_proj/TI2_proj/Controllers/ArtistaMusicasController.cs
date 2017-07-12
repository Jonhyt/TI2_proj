using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI2_proj.Models;

namespace TI2_proj.Controllers
{
    public class ArtistaMusicasController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: ArtistaMusicas
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.ArtistaMusica.Include(a => a.Artista).Include(a => a.Musica).ToList());
            return View(db.ArtistaMusica.Where(a => a.Dono == User.Identity.Name).Include(a => a.Artista).Include(a => a.Musica).ToList());
        }

        // GET: ArtistaMusicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistaMusica artistaMusica = db.ArtistaMusica.Find(id);
            if (artistaMusica == null)
            {
                return HttpNotFound();
            }
            return View(artistaMusica);
        }

        // GET: ArtistaMusicas/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo");
            return View();
        }

        // POST: ArtistaMusicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtMusId,MusicaFK,ArtistaFK,Dono")] ArtistaMusica artistaMusica)
        {
            if (ModelState.IsValid)
            {
                artistaMusica.Dono = User.Identity.Name;
                db.ArtistaMusica.Add(artistaMusica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaFK = new SelectList(db.Artista, "ArtistaID", "Nome", artistaMusica.ArtistaFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", artistaMusica.MusicaFK);
            return View(artistaMusica);
        }

        // GET: ArtistaMusicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistaMusica artistaMusica = db.ArtistaMusica.Find(id);
            if (artistaMusica == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaFK = new SelectList(db.Artista, "ArtistaID", "Nome", artistaMusica.ArtistaFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", artistaMusica.MusicaFK);
            return View(artistaMusica);
        }

        // POST: ArtistaMusicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtMusId,MusicaFK,ArtistaFK,Dono")] ArtistaMusica artistaMusica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistaMusica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaFK = new SelectList(db.Artista, "ArtistaID", "Nome", artistaMusica.ArtistaFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", artistaMusica.MusicaFK);
            return View(artistaMusica);
        }

        // GET: ArtistaMusicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistaMusica artistaMusica = db.ArtistaMusica.Find(id);
            if (artistaMusica == null)
            {
                return HttpNotFound();
            }
            return View(artistaMusica);
        }

        // POST: ArtistaMusicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistaMusica artistaMusica = db.ArtistaMusica.Find(id);
            db.ArtistaMusica.Remove(artistaMusica);
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
