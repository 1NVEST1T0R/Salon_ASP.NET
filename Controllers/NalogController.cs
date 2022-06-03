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
    public class NalogController : Controller
    {
        private Frizerski_SalonEntities3 db = new Frizerski_SalonEntities3();

        // GET: Nalog
        public ActionResult Index()
        {
            return View(db.Nalog.ToList());
        }

        // GET: Nalog/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // GET: Nalog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NalogID,Korisnicko_ime,Sifra,TipKorisnika")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Nalog.Add(nalog);
                db.SaveChanges();
                return RedirectToAction("Back");
            }

            return View(nalog);
        }

        // GET: Nalog/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NalogID,Korisnicko_ime,Sifra,TipKorisnika")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nalog);
        }

        // GET: Nalog/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nalog nalog = db.Nalog.Find(id);
            db.Nalog.Remove(nalog);
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

        public ActionResult Enter()
        {
            return View();
        }

        public ActionResult Back()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        
        public ActionResult MenadzerLogin()
        {
            return View("~/Views/Home/Menadzer.cshtml");
        }

        public ActionResult KlijentLogin()
        {
            return View("~/Views/Home/Klijent.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enter([Bind(Include = "NalogID,Korisnicko_ime,Sifra,TipKorisnika")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                var nalogKorisnika = db.Nalog.Where(t => t.Korisnicko_ime == nalog.Korisnicko_ime).ToList();

                if (nalogKorisnika.Count > 0)
                {
                    if (nalogKorisnika[0].TipKorisnika == true)
                    {
                        return RedirectToAction("MenadzerLogin");
                    }
                    else
                    {
                        return RedirectToAction("KlijentLogin");
                    }
                }
                else
                {
                    return RedirectToAction("Enter");
                }
            }

            return View();
        }

    }
}
