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
    public class CompositorMusicasController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: CompositorMusicas
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.CompositorMusica.Include(c => c.Compositor).Include(c => c.Musica).ToList());
            return View(db.CompositorMusica.Where(a => a.Dono == User.Identity.Name).Include(c => c.Compositor).Include(c => c.Musica).ToList());
        }

        // GET: CompositorMusicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompositorMusica compositorMusica = db.CompositorMusica.Find(id);
            if (compositorMusica == null)
            {
                return HttpNotFound();
            }
            return View(compositorMusica);
        }

        // GET: CompositorMusicas/Create
        public ActionResult Create()
        {
            ViewBag.CompositorFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo");
            return View();
        }

        // POST: CompositorMusicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComMusID,MusicaFK,CompositorFK,Dono")] CompositorMusica compositorMusica)
        {
            if (ModelState.IsValid)
            {
                compositorMusica.Dono = User.Identity.Name;
                db.CompositorMusica.Add(compositorMusica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompositorFK = new SelectList(db.Artista, "ArtistaID", "Nome", compositorMusica.CompositorFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", compositorMusica.MusicaFK);
            return View(compositorMusica);
        }

        // GET: CompositorMusicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompositorMusica compositorMusica = db.CompositorMusica.Find(id);
            if (compositorMusica == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompositorFK = new SelectList(db.Artista, "ArtistaID", "Nome", compositorMusica.CompositorFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", compositorMusica.MusicaFK);
            return View(compositorMusica);
        }

        // POST: CompositorMusicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComMusID,MusicaFK,CompositorFK,Dono")] CompositorMusica compositorMusica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compositorMusica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompositorFK = new SelectList(db.Artista, "ArtistaID", "Nome", compositorMusica.CompositorFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", compositorMusica.MusicaFK);
            return View(compositorMusica);
        }

        // GET: CompositorMusicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompositorMusica compositorMusica = db.CompositorMusica.Find(id);
            if (compositorMusica == null)
            {
                return HttpNotFound();
            }
            return View(compositorMusica);
        }

        // POST: CompositorMusicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompositorMusica compositorMusica = db.CompositorMusica.Find(id);
            db.CompositorMusica.Remove(compositorMusica);
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
