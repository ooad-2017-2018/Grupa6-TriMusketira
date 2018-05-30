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
    public class StavkeNarudzbeController : Controller
    {
        private GurmaniContext db = new GurmaniContext();

        // GET: StavkeNarudzbe
        public ActionResult Index()
        {
            return View(db.StavkeNarudzba.ToList());
        }

        // GET: StavkeNarudzbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (stavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(stavkeNarudzbe);
        }

        // GET: StavkeNarudzbe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StavkeNarudzbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idNarudzbe,idJela")] StavkeNarudzbe stavkeNarudzbe)
        {
            if (ModelState.IsValid)
            {
                db.StavkeNarudzba.Add(stavkeNarudzbe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stavkeNarudzbe);
        }

        // GET: StavkeNarudzbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (stavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(stavkeNarudzbe);
        }

        // POST: StavkeNarudzbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idNarudzbe,idJela")] StavkeNarudzbe stavkeNarudzbe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkeNarudzbe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stavkeNarudzbe);
        }

        // GET: StavkeNarudzbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzba.Find(id);
            if (stavkeNarudzbe == null)
            {
                return HttpNotFound();
            }
            return View(stavkeNarudzbe);
        }

        // POST: StavkeNarudzbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzba.Find(id);
            db.StavkeNarudzba.Remove(stavkeNarudzbe);
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
