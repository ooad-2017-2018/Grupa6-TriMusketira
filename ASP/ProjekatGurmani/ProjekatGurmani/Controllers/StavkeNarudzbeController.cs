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
    public class StavkeNarudzbaController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: StavkeNarudzba
        public ActionResult Index()
        {
            return View(db.StavkeNarudzba.ToList());
        }

        // GET: StavkeNarudzba/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe StavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (StavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(StavkeNarudzbe);
        }

        // GET: StavkeNarudzba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StavkeNarudzba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idNarudzbe, idJela")] StavkeNarudzbe StavkeNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.StavkeNarudzba.Add(StavkeNarudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(StavkeNarudzba);
        }

        // GET: StavkeNarudzba/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe StavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (StavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(StavkeNarudzbe);
        }

        // POST: StavkeNarudzba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idNarudzbe, idJela")] StavkeNarudzbe StavkeNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(StavkeNarudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(StavkeNarudzba);
        }

        // GET: StavkeNarudzba/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe StavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (StavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(StavkeNarudzbe);
        }

        // POST: StavkeNarudzba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StavkeNarudzbe StavkeNarudzbe = db.StavkeNarudzba.Find(id);
            db.StavkeNarudzba.Remove(StavkeNarudzbe);
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