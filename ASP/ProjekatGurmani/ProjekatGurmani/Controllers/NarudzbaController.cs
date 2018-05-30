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
    public class NarudzbaController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: Narudzba
        public ActionResult Index()
        {
            return View(db.Narudzbe.ToList());
        }

        // GET: Narudzba/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba Narudzba = db.Narudzbe.Find(id);
            if (Narudzba == null)
            {
                return HttpNotFound();
            }
            return View(Narudzba);
        }

        // GET: Narudzba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Narudzba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idKupca")] Narudzba Narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Narudzbe.Add(Narudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Narudzba);
        }

        // GET: Narudzba/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba Narudzba = db.Narudzbe.Find(id);
            if (Narudzba == null)
            {
                return HttpNotFound();
            }
            return View(Narudzba);
        }

        // POST: Narudzba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idKupca")] Narudzba Narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Narudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Narudzba);
        }

        // GET: Narudzba/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba Narudzba = db.Narudzbe.Find(id);
            if (Narudzba == null)
            {
                return HttpNotFound();
            }
            return View(Narudzba);
        }

        // POST: Narudzba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Narudzba Narudzba = db.Narudzbe.Find(id);
            db.Narudzbe.Remove(Narudzba);
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