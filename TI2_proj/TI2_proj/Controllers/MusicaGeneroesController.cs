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
    public class MusicaGeneroesController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: MusicaGeneroes
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.MusicaGenero.Include(m => m.Genero).Include(m => m.Musica).ToList());
            return View(db.MusicaGenero.Where(a => a.Dono == User.Identity.Name).Include(m => m.Genero).Include(m => m.Musica).ToList());
        }

        // GET: MusicaGeneroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaGenero musicaGenero = db.MusicaGenero.Find(id);
            if (musicaGenero == null)
            {
                return HttpNotFound();
            }
            return View(musicaGenero);
        }

        // GET: MusicaGeneroes/Create
        public ActionResult Create()
        {
            ViewBag.GeneroFK = new SelectList(db.Genero, "GeneroID", "Nome");
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo");
            return View();
        }

        // POST: MusicaGeneroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusGenID,MusicaFK,GeneroFK,Dono")] MusicaGenero musicaGenero)
        {
            if (ModelState.IsValid)
            {
                musicaGenero.Dono = User.Identity.Name;
                db.MusicaGenero.Add(musicaGenero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroFK = new SelectList(db.Genero, "GeneroID", "Nome", musicaGenero.GeneroFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaGenero.MusicaFK);
            return View(musicaGenero);
        }

        // GET: MusicaGeneroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaGenero musicaGenero = db.MusicaGenero.Find(id);
            if (musicaGenero == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroFK = new SelectList(db.Genero, "GeneroID", "Nome", musicaGenero.GeneroFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaGenero.MusicaFK);
            return View(musicaGenero);
        }

        // POST: MusicaGeneroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusGenID,MusicaFK,GeneroFK,Dono")] MusicaGenero musicaGenero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicaGenero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroFK = new SelectList(db.Genero, "GeneroID", "Nome", musicaGenero.GeneroFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaGenero.MusicaFK);
            return View(musicaGenero);
        }

        // GET: MusicaGeneroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaGenero musicaGenero = db.MusicaGenero.Find(id);
            if (musicaGenero == null)
            {
                return HttpNotFound();
            }
            return View(musicaGenero);
        }

        // POST: MusicaGeneroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicaGenero musicaGenero = db.MusicaGenero.Find(id);
            db.MusicaGenero.Remove(musicaGenero);
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
