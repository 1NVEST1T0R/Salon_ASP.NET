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
    public class TerminController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Termin
        public ActionResult Index()
        {
            var termin = db.Termin.Include(t => t.Frizura);
            return View(termin.ToList());
        }

        // GET: Termin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termin.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // GET: Termin/Create
        public ActionResult Create()
        {
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja");
            return View();
        }

        // POST: Termin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminID,FrizuraID,Datum,Vreme")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Termin.Add(termin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", termin.FrizuraID);
            return View(termin);
        }

        // GET: Termin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termin.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", termin.FrizuraID);
            return View(termin);
        }

        // POST: Termin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminID,FrizuraID,Datum,Vreme")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizuraID = new SelectList(db.Frizura, "FrizuraID", "Boja", termin.FrizuraID);
            return View(termin);
        }

        // GET: Termin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termin.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // POST: Termin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termin termin = db.Termin.Find(id);
            db.Termin.Remove(termin);
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
