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
    public class RacunController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Racun
        public ActionResult Index()
        {
            var racun = db.Racun.Include(r => r.Frizura).Include(r => r.Naplata);
            return View(racun.ToList());
        }

        // GET: Racun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racun/Create
        public ActionResult Create()
        {
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja");
            ViewBag.RacunID = new SelectList(db.Naplata, "RacunID", "RacunID");
            return View();
        }

        // POST: Racun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacunID,FrizuraID,Datum,Vreme,Vrednost,Obradjen,Storniran")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racun.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", racun.FrizuraID);
            ViewBag.RacunID = new SelectList(db.Naplata, "RacunID", "RacunID", racun.RacunID);
            return View(racun);
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", racun.FrizuraID);
            ViewBag.RacunID = new SelectList(db.Naplata, "RacunID", "RacunID", racun.RacunID);
            return View(racun);
        }

        // POST: Racun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RacunID,FrizuraID,Datum,Vreme,Vrednost,Obradjen,Storniran")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", racun.FrizuraID);
            ViewBag.RacunID = new SelectList(db.Naplata, "RacunID", "RacunID", racun.RacunID);
            return View(racun);
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racun.Find(id);
            db.Racun.Remove(racun);
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
