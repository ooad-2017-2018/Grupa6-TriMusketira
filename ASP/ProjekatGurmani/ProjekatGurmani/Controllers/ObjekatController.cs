using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatGurmani.Models;

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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekti.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
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
        public ActionResult Create([Bind(Include = "id,ime,prezime,adresa,telefon,email,password,grad,naziv")] Objekat objekat)
        {
            if (ModelState.IsValid)
            {
                db.Objekti.Add(objekat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objekat);
        }

        // GET: Objekat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekti.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
        }

        // POST: Objekat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ime,prezime,adresa,telefon,email,password,grad,naziv")] Objekat objekat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objekat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objekat);
        }

        // GET: Objekat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekti.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
        }

        // POST: Objekat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objekat objekat = db.Objekti.Find(id);
            db.Objekti.Remove(objekat);
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
