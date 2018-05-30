using ProjekatGurmani.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjekatGurmani.Controllers
{
    public class ObjekatController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: Objekat
        public ActionResult Index()
        {
            return View(db.Objekti.ToList());
        }

        // GET: Objekat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat Objekat = db.Objekti.Find(id);
            if (Objekat == null)
            {
                return HttpNotFound();
            }
            return View(Objekat);
        }

        // GET: Objekat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objekat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ime,prezime,adresa,telefon,username,password,email,grad")] Objekat Objekat)
        {
            if (ModelState.IsValid)
            {
                db.Objekti.Add(Objekat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Objekat);
        }

        // GET: Objekat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat Objekat = db.Objekti.Find(id);
            if (Objekat == null)
            {
                return HttpNotFound();
            }
            return View(Objekat);
        }

        // POST: Objekat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ime,prezime,adresa,telefon,username,password,email,grad")] Objekat Objekat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Objekat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Objekat);
        }

        // GET: Objekat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat Objekat = db.Objekti.Find(id);
            if (Objekat == null)
            {
                return HttpNotFound();
            }
            return View(Objekat);
        }

        // POST: Objekat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Objekat Objekat = db.Objekti.Find(id);
            db.Objekti.Remove(Objekat);
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