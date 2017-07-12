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
    public class BandasController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: Bandas
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.Bandas.Include(b => b.Banda).Include(b => b.Membro).ToList());
            return View(db.Bandas.Where(a => a.Dono == User.Identity.Name).Include(b => b.Banda).Include(b => b.Membro).ToList());
        }

        // GET: Bandas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandas bandas = db.Bandas.Find(id);
            if (bandas == null)
            {
                return HttpNotFound();
            }
            return View(bandas);
        }

        // GET: Bandas/Create
        public ActionResult Create()
        {
            ViewBag.BandaFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            ViewBag.MembroFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            return View();
        }

        // POST: Bandas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BandaID,BandaFK,MembroFK,Dono")] Bandas bandas)
        {
            if (ModelState.IsValid)
            {
                bandas.Dono = User.Identity.Name;
                db.Bandas.Add(bandas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BandaFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.BandaFK);
            ViewBag.MembroFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.MembroFK);
            return View(bandas);
        }

        // GET: Bandas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandas bandas = db.Bandas.Find(id);
            if (bandas == null)
            {
                return HttpNotFound();
            }
            ViewBag.BandaFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.BandaFK);
            ViewBag.MembroFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.MembroFK);
            return View(bandas);
        }

        // POST: Bandas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BandaID,BandaFK,MembroFK,Dono")] Bandas bandas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bandas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BandaFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.BandaFK);
            ViewBag.MembroFK = new SelectList(db.Artista, "ArtistaID", "Nome", bandas.MembroFK);
            return View(bandas);
        }

        // GET: Bandas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandas bandas = db.Bandas.Find(id);
            if (bandas == null)
            {
                return HttpNotFound();
            }
            return View(bandas);
        }

        // POST: Bandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bandas bandas = db.Bandas.Find(id);
            db.Bandas.Remove(bandas);
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
