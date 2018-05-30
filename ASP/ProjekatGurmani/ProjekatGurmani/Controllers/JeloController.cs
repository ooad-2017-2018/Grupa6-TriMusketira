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
    public class JeloController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: Jelo
        public ActionResult Index()
        {
            return View(db.Jela.ToList());
        }

        // GET: Jelo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jela.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        // GET: Jelo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazivJela,vrsta,cijena,idObjekta")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                db.Jela.Add(jelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jelo);
        }

        // GET: Jelo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jela.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        // POST: Jelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazivJela,vrsta,cijena,idObjekta")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jelo);
        }

        // GET: Jelo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jelo jelo = db.Jela.Find(id);
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        // POST: Jelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jelo jelo = db.Jela.Find(id);
            db.Jela.Remove(jelo);
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
