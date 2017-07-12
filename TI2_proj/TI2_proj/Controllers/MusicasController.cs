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
        public ActionResult Create([Bind(Include = "MusicaID,Titulo,Duracao,NumFaixa,AlbumFK")] Musicas musicas)
        {
            if (ModelState.IsValid)
            {
                musicas.Dono = User.Identity.Name;
                db.Musicas.Add(musicas);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Img", musicas.AlbumFK);
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
            ViewBag.AlbumFK = new SelectList(db.Album, "AlbumId", "Img", musicas.AlbumFK);
            return View(musicas);
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
