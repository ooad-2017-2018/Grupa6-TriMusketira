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
    public class KupacController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: Kupac
        public ActionResult Index()
        {
            return View(db.Kupci.ToList());
        }

        // GET: Kupac/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac Kupac = db.Kupci.Find(id);
            if (Kupac == null)
            {
                return HttpNotFound();
            }
            return View(Kupac);
        }

        // GET: Kupac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ime,prezime,adresa,telefon,username,password,email,grad")] Kupac Kupac)
        {
            if (ModelState.IsValid)
            {
                db.Kupci.Add(Kupac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Kupac);
        }

        // GET: Kupac/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac Kupac = db.Kupci.Find(id);
            if (Kupac == null)
            {
                return HttpNotFound();
            }
            return View(Kupac);
        }

        // POST: Kupac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ime,prezime,adresa,telefon,username,password,email,grad")] Kupac Kupac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Kupac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Kupac);
        }

        // GET: Kupac/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac Kupac = db.Kupci.Find(id);
            if (Kupac == null)
            {
                return HttpNotFound();
            }
            return View(Kupac);
        }

        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kupac Kupac = db.Kupci.Find(id);
            db.Kupci.Remove(Kupac);
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