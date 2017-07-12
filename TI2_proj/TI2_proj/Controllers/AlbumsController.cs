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
    [Authorize]
    public class AlbumsController : Controller
    {
        private MusicasDB db = new MusicasDB();

        // GET: Albums
        public ActionResult Index()
        {
            if(User.IsInRole("Admin"))
                return View(db.Album.Include(a => a.Autor).Include(a => a.Edit).ToList());
            return View(db.Album.Where(a => a.Dono==User.Identity.Name).Include(a => a.Autor).Include(a => a.Edit).ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.AutorFK = new SelectList(db.Artista, "ArtistaID", "Nome");
            ViewBag.EditFK = new SelectList(db.Editora, "EditoraId", "Nome");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Img,Titulo,AutorFK,EditFK")] Album album)
        {
            if (ModelState.IsValid)
            {
                album.Dono = User.Identity.Name;
                db.Album.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorFK = new SelectList(db.Artista, "ArtistaID", "Nome", album.AutorFK);
            ViewBag.EditFK = new SelectList(db.Editora, "EditoraId", "Nome", album.EditFK);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorFK = new SelectList(db.Artista, "ArtistaID", "Nome", album.AutorFK);
            ViewBag.EditFK = new SelectList(db.Editora, "EditoraId", "Nome", album.EditFK);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Img,Titulo,AutorFK,EditFK")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorFK = new SelectList(db.Artista, "ArtistaID", "Nome", album.AutorFK);
            ViewBag.EditFK = new SelectList(db.Editora, "EditoraId", "Nome", album.EditFK);
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Album.Find(id);
            db.Album.Remove(album);
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
