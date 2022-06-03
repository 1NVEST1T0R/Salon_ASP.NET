using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon.Models;

namespace Salon.Controllers
{
    public class KomentarController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Komentar
        public ActionResult Index()
        {
            var komentar = db.Komentar.Include(k => k.Frizura);
            return View(komentar.ToList());
        }

        // GET: Komentar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // GET: Komentar/Create
        public ActionResult Create()
        {
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja");
            return View();
        }

        // POST: Komentar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KomentarID,FrizuraID,Sadrzaj,Ocena")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Komentar.Add(komentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", komentar.FrizuraID);
            return View(komentar);
        }

        // GET: Komentar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", komentar.FrizuraID);
            return View(komentar);
        }

        // POST: Komentar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KomentarID,FrizuraID,Sadrzaj,Ocena")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", komentar.FrizuraID);
            return View(komentar);
        }

        // GET: Komentar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = db.Komentar.Find(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komentar komentar = db.Komentar.Find(id);
            db.Komentar.Remove(komentar);
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
