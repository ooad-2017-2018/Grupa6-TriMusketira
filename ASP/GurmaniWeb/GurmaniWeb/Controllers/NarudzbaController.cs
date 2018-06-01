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
    public class NarudzbaController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Narudzba
        public IQueryable<Narudzba> GetNarudzba()
        {
            return db.Narudzba;
        }

        // GET: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult GetNarudzba(int id)
        {
            Narudzba narudzba = db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return Ok(narudzba);
        }

        // PUT: api/Narudzba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzba(int id, Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzba.id)
            {
                return BadRequest();
            }

            db.Entry(narudzba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaExists(id))
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

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult PostNarudzba(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Narudzba.Add(narudzba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = narudzba.id }, narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult DeleteNarudzba(int id)
        {
            Narudzba narudzba = db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            db.Narudzba.Remove(narudzba);
            db.SaveChanges();

            return Ok(narudzba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaExists(int id)
        {
            return db.Narudzba.Count(e => e.id == id) > 0;
        }
    }
}