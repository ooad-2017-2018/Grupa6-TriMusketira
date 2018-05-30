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
    public class NarudzbaController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: Narudzbas
        public ActionResult Index()
        {
            return View(db.Narudzbe.ToList());
        }

        // GET: Narudzbas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbe.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

        // GET: Narudzbas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Narudzbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idKupca")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Narudzbe.Add(narudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(narudzba);
        }

        // GET: Narudzbas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbe.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

        // POST: Narudzbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idKupca")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(narudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(narudzba);
        }

        // GET: Narudzbas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbe.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

        // POST: Narudzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Narudzba narudzba = db.Narudzbe.Find(id);
            db.Narudzbe.Remove(narudzba);
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
