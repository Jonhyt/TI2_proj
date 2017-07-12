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
    public class MusicaMoodsController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: MusicaMoods
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.MusicaMood.Include(m => m.Mood).Include(m => m.Musica).ToList());
            return View(db.MusicaMood.Where(a => a.Dono == User.Identity.Name).Include(m => m.Mood).Include(m => m.Musica).ToList());
        }

        // GET: MusicaMoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaMood musicaMood = db.MusicaMood.Find(id);
            if (musicaMood == null)
            {
                return HttpNotFound();
            }
            return View(musicaMood);
        }

        // GET: MusicaMoods/Create
        public ActionResult Create()
        {
            ViewBag.MoodFK = new SelectList(db.Mood, "MoodID", "Nome");
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo");
            return View();
        }

        // POST: MusicaMoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusGenID,MusicaFK,MoodFK,Dono")] MusicaMood musicaMood)
        {
            if (ModelState.IsValid)
            {
                musicaMood.Dono = User.Identity.Name;
                db.MusicaMood.Add(musicaMood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MoodFK = new SelectList(db.Mood, "MoodID", "Nome", musicaMood.MoodFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaMood.MusicaFK);
            return View(musicaMood);
        }

        // GET: MusicaMoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaMood musicaMood = db.MusicaMood.Find(id);
            if (musicaMood == null)
            {
                return HttpNotFound();
            }
            ViewBag.MoodFK = new SelectList(db.Mood, "MoodID", "Nome", musicaMood.MoodFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaMood.MusicaFK);
            return View(musicaMood);
        }

        // POST: MusicaMoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusGenID,MusicaFK,MoodFK,Dono")] MusicaMood musicaMood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicaMood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MoodFK = new SelectList(db.Mood, "MoodID", "Nome", musicaMood.MoodFK);
            ViewBag.MusicaFK = new SelectList(db.Musicas, "MusicaID", "Titulo", musicaMood.MusicaFK);
            return View(musicaMood);
        }

        // GET: MusicaMoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicaMood musicaMood = db.MusicaMood.Find(id);
            if (musicaMood == null)
            {
                return HttpNotFound();
            }
            return View(musicaMood);
        }

        // POST: MusicaMoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicaMood musicaMood = db.MusicaMood.Find(id);
            db.MusicaMood.Remove(musicaMood);
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
