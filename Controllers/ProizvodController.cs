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
    public class ProizvodController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Proizvod
        public ActionResult Index()
        {
            var proizvod = db.Proizvod.Include(p => p.Frizura);
            return View(proizvod.ToList());
        }

        // GET: Proizvod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvod.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: Proizvod/Create
        public ActionResult Create()
        {
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja");
            return View();
        }

        // POST: Proizvod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProizvodID,FrizuraID,Ime,Proizvodjac,Cena,Dostupnost")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvod.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", proizvod.FrizuraID);
            return View(proizvod);
        }

        // GET: Proizvod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvod.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", proizvod.FrizuraID);
            return View(proizvod);
        }

        // POST: Proizvod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProizvodID,FrizuraID,Ime,Proizvodjac,Cena,Dostupnost")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", proizvod.FrizuraID);
            return View(proizvod);
        }

        // GET: Proizvod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvod.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvod proizvod = db.Proizvod.Find(id);
            db.Proizvod.Remove(proizvod);
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
