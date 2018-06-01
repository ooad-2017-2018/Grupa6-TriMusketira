using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GurmaniWeb.Models;

namespace GurmaniWeb.Controllers
{
    public class KupacController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Kupac
        public IQueryable<Kupac> GetKupac()
        {
            return db.Kupac;
        }

        // GET: api/Kupac/5
        [ResponseType(typeof(Kupac))]
        public IHttpActionResult GetKupac(int id)
        {
            Kupac kupac = db.Kupac.Find(id);
            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(kupac);
        }

        // PUT: api/Kupac/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKupac(int id, Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kupac.id)
            {
                return BadRequest();
            }

            db.Entry(kupac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kupac
        [ResponseType(typeof(Kupac))]
        public IHttpActionResult PostKupac(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kupac.Add(kupac);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kupac.id }, kupac);
        }

        // DELETE: api/Kupac/5
        [ResponseType(typeof(Kupac))]
        public IHttpActionResult DeleteKupac(int id)
        {
            Kupac kupac = db.Kupac.Find(id);
            if (kupac == null)
            {
                return NotFound();
            }

            db.Kupac.Remove(kupac);
            db.SaveChanges();

            return Ok(kupac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KupacExists(int id)
        {
            return db.Kupac.Count(e => e.id == id) > 0;
        }
    }
}