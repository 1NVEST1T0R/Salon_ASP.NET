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
    public class FrizuraController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Frizura
        public ActionResult Index()
        {
            var frizura = db.Frizura.Include(f => f.Nalog);
            return View(frizura.ToList());
        }

        // GET: Frizura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizura frizura = db.Frizura.Find(id);
            if (frizura == null)
            {
                return HttpNotFound();
            }
            return View(frizura);
        }

        // GET: Frizura/Create
        public ActionResult Create()
        {
            ViewBag.NalogID = new SelectList(db.Nalog, "NalogID", "Korisnicko_ime");
            return View();
        }

        // POST: Frizura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrizuraID,NalogID,Duzina,Boja,Preparati,Frizura1,Tip,Gustina")] Frizura frizura)
        {
            if (ModelState.IsValid)
            {
                db.Frizura.Add(frizura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NalogID = new SelectList(db.Nalog, "NalogID", "Korisnicko_ime", frizura.NalogID);
            return View(frizura);
        }

        // GET: Frizura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizura frizura = db.Frizura.Find(id);
            if (frizura == null)
            {
                return HttpNotFound();
            }
            ViewBag.NalogID = new SelectList(db.Nalog, "NalogID", "Korisnicko_ime", frizura.NalogID);
            return View(frizura);
        }

        // POST: Frizura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrizuraID,NalogID,Duzina,Boja,Preparati,Frizura1,Tip,Gustina")] Frizura frizura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frizura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NalogID = new SelectList(db.Nalog, "NalogID", "Korisnicko_ime", frizura.NalogID);
            return View(frizura);
        }

        // GET: Frizura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizura frizura = db.Frizura.Find(id);
            if (frizura == null)
            {
                return HttpNotFound();
            }
            return View(frizura);
        }

        // POST: Frizura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frizura frizura = db.Frizura.Find(id);
            db.Frizura.Remove(frizura);
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
